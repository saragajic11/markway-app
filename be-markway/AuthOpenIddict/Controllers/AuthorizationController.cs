// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Security.Claims;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Markway.AuthOpenIddict.Constants;
using Markway.Commons.Authorization;

using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

using UsersService;

using static BCrypt.Net.BCrypt;
using static UsersService.GrpcUser;

namespace Markway.AuthOpenIddict.Controllers
{
    public class AuthorizationController : Controller
    {
        private const string EXPIRATION_DATE = "exp";
        private readonly GrpcUserClient _grpcUserClient;
        private readonly ILogger _logger;

        public AuthorizationController(GrpcUserClient grpcUserClient,  ILogger<AuthorizationController> logger)
        {
            _grpcUserClient = grpcUserClient;
            _logger = logger;
        }

        [HttpGet(Endpoints.AUTHORIZE)]
        [HttpPost(Endpoints.AUTHORIZE)]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Authorize()
        {
            OpenIddictRequest request = HttpContext.GetOpenIddictServerRequest() ??
                throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            AuthenticateResult authentication = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // If the user principal can't be extracted, redirect the user to the login page.
            if (!authentication.Succeeded)
            {
                ChallengeResult challenge = Challenge(
                    authenticationSchemes: CookieAuthenticationDefaults.AuthenticationScheme,
                    properties: new AuthenticationProperties
                    {
                        RedirectUri = Request.PathBase + Request.Path + QueryString.Create(
                            Request.HasFormContentType ? Request.Form.ToList() : Request.Query.ToList())
                    });
                return challenge;
            }

            _ = AuthenticationMethod.MOBILE_PHONE.Equals(authentication.Principal.GetClaim(ClaimTypes.AuthenticationMethod));

            UserRequest userRequest = new UserRequest { Username = authentication.Principal.Identity.Name };

            UserReply user = await _grpcUserClient.GetUserByUsernameAsync(userRequest);

            List<Claim> claims = new()
            {
                new Claim(OpenIddictConstants.Claims.Subject, authentication.Principal.Identity.Name),
                new Claim(Claims.CLAIM_UID, $"{user.Id}").SetDestinations(OpenIddictConstants.Destinations.AccessToken),
            };
            foreach (string role in user.Roles)
            {
                foreach (string permission in Roles.RolePermissions.GetValueOrDefault(role))
                {
                    claims.Add(new Claim(Claims.CLAIM_PERMISSIONS, permission).SetDestinations(OpenIddictConstants.Destinations.AccessToken));
                }

                claims.Add(new Claim(Claims.CLAIM_ROLES, role).SetDestinations(OpenIddictConstants.Destinations.AccessToken));
            }

            ClaimsIdentity claimsIdentity = new(claims, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            claimsPrincipal.SetScopes(request.GetScopes());

            return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        [HttpPost(Endpoints.ADMIN_TOKEN), Produces("application/json")]
        public async Task<IActionResult> ExchangeAdminToken()
        {
            OpenIddictRequest request = HttpContext.GetOpenIddictServerRequest() ??
                                    throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            ClaimsPrincipal claimsPrincipal;

            if (request.IsPasswordGrantType())
            {
                CredentialsResponse credentials = await ResolveUserCredentials(request.Username);

                if (!UserStatus.ACTIVE.Equals(Enum.Parse(typeof(UserStatus), credentials.Status))
                    || !credentials.Roles.Contains(Role.SUPER_ADMIN.ToString()))
                {
                    throw new BadHttpRequestException("The specified user credentials are invalid.");
                }

                ClaimsIdentity claimsIdentity = await ResolveUserIdentity(request.Password, credentials);
                claimsPrincipal = new(claimsIdentity);
                claimsPrincipal.SetScopes(new string[] { OpenIddictConstants.Scopes.OpenId, OpenIddictConstants.Scopes.OfflineAccess });

                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            if (request.IsRefreshTokenGrantType() || request.IsAuthorizationCodeGrantType())
            {
                claimsPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            throw new NotImplementedException("The specified grant is not implemented.");
        }

        [HttpPost(Endpoints.TOKEN), Produces("application/json")]
        public async Task<IActionResult> Exchange()
        {
            OpenIddictRequest request = HttpContext.GetOpenIddictServerRequest() ??
                                    throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            ClaimsPrincipal claimsPrincipal;

            if (request.IsPasswordGrantType())
            {
                CredentialsResponse credentials = await ResolveUserCredentials(request.Username);

                if (!UserStatus.ACTIVE.Equals(Enum.Parse(typeof(UserStatus), credentials.Status)))
                {
                    throw new BadHttpRequestException("The specified user credentials are invalid.");
                }

                ClaimsIdentity claimsIdentity = await ResolveUserIdentity(request.Password, credentials);
                claimsPrincipal = new(claimsIdentity);
                claimsPrincipal.SetScopes(new string[] { OpenIddictConstants.Scopes.OpenId, OpenIddictConstants.Scopes.OfflineAccess });

                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            if (request.IsRefreshTokenGrantType() || request.IsAuthorizationCodeGrantType())
            {
                claimsPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            if (request.IsClientCredentialsGrantType())
            {
                ClaimsIdentity identity = new(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                identity.AddClaim(OpenIddictConstants.Claims.Subject, request.ClientId ?? throw new InvalidOperationException());

                claimsPrincipal = new ClaimsPrincipal(identity);
                claimsPrincipal.SetScopes(request.GetScopes());

                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            throw new NotImplementedException("The specified grant is not implemented.");
        }

        [Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet(Endpoints.USER_INFO)]
        public async Task<IActionResult> Userinfo()
        {
            ClaimsPrincipal claimsPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
            try
            {
                return Ok(new
                {
                    Name = claimsPrincipal.GetClaim(OpenIddictConstants.Claims.Subject),
                    UID = claimsPrincipal.GetClaim(Claims.CLAIM_UID),
                });
            }
            catch (Exception)
            {
                return new NoContentResult();
            }
        }

        private async Task<ClaimsIdentity> ResolveUserIdentity(string password, CredentialsResponse credentials)
        {
            if (!Verify(password, credentials.Password))
            {
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }

            UserRequest userRequest = new UserRequest { Username = credentials.Username };
            UserReply user = await _grpcUserClient.GetUserByUsernameAsync(userRequest);

            List<Claim> claims = new()
            {
                new Claim(OpenIddictConstants.Claims.Subject, credentials.Username),
                new Claim(Claims.CLAIM_UID, $"{user.Id}").SetDestinations(OpenIddictConstants.Destinations.AccessToken),
                new Claim(ClaimTypes.Name, credentials.Username),
                new Claim(ClaimTypes.Name, credentials.Username),
                new Claim(ClaimTypes.Email, credentials.Username),
                new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethod.EMAIL)
            };

            foreach (string role in user.Roles)
            {
                foreach (string permission in Roles.RolePermissions.GetValueOrDefault(role))
                {
                    claims.Add(new Claim(Claims.CLAIM_PERMISSIONS, permission).SetDestinations(OpenIddictConstants.Destinations.AccessToken));
                }

                claims.Add(new Claim(Claims.CLAIM_ROLES, role).SetDestinations(OpenIddictConstants.Destinations.AccessToken));
            }

            return new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async Task<CredentialsResponse> ResolveUserCredentials(string username)
        {
            try
            {
                UserRequest userRequest = new UserRequest { Username = username };
                return await _grpcUserClient.GetUserCredentialsAsync(userRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in AuthenticationController in GetUserCredentialsAsync {e.Message} in {e.StackTrace}\n InnerException: {e.InnerException}");
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }
        }

        private async Task<CredentialsResponse> VerifyUserPhoneNumberAsync(string username, string password)
        {
            try
            {
                UserSmsActivationRequest smsActivationRequest = new UserSmsActivationRequest { Username = username, Password = password };
                return await _grpcUserClient.VerifyUserPhoneNumberAsync(smsActivationRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in AuthenticationController in VerifyUserPhoneNumberAsync {e.Message} in {e.StackTrace}\n InnerException: {e.InnerException}");
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }
        }

        private async Task<CredentialsResponse> VerifyRecoveredUserPhoneNumberAsync(string username, string password)
        {
            try
            {
                UserSmsActivationRequest smsActivationRequest = new UserSmsActivationRequest { Username = username, Password = password };
                return await _grpcUserClient.VerifyRecoveredUserPhoneNumberAsync(smsActivationRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in AuthenticationController in VerifyRecoveredUserPhoneNumberAsync {e.Message} in {e.StackTrace}\n");
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }
        }
    }
}