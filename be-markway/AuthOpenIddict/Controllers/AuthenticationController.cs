// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Markway.AuthOpenIddict.Views.Account;
using Markway.Commons.Authorization;

using UsersService;

using static BCrypt.Net.BCrypt;
using static UsersService.GrpcUser;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Markway.AuthOpenIddict.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger _logger;
        private readonly GrpcUserClient _grpcUserClient;

        public AuthenticationController(ILogger<AuthenticationController> logger, GrpcUserClient grpcUserClient)
        {
            _logger = logger;
            _grpcUserClient = grpcUserClient;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto request)
        {
            ViewData["ReturnUrl"] = request.ReturnUrl;

            if (ModelState.IsValid)
            {
                CredentialsResponse credentials = await ResolveUserCredentials(request);

                if (credentials.IsPhoneNumberRegistration && UserStatus.STAGED.Equals(Enum.Parse(typeof(UserStatus), credentials.Status)))
                {
                    await VerifyUserPhoneNumberAsync(request);
                    return await ResolveUserIdentity(request, credentials);
                }

                if (!UserStatus.ACTIVE.Equals(Enum.Parse(typeof(UserStatus), credentials.Status)))
                {
                    throw new BadHttpRequestException("The specified user credentials are invalid.");
                }

                return await ResolveUserIdentity(request, credentials);
            }

            return View(request);
        }

        private async Task<IActionResult> ResolveUserIdentity(LoginDto request, CredentialsResponse credentials)
        {
            if (!Verify(request.Password, credentials.Password))
            {
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }

            List<Claim> claims = new();
            if (credentials.IsPhoneNumberRegistration)
            {
                claims.Add(new Claim(ClaimTypes.Name, credentials.Username));
                claims.Add(new Claim(ClaimTypes.MobilePhone, credentials.Username));
                claims.Add(new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethod.MOBILE_PHONE));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Name, credentials.Username));
                claims.Add(new Claim(ClaimTypes.Email, credentials.Username));
                claims.Add(new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethod.EMAIL));
            }

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            if (Url.IsLocalUrl(request.ReturnUrl))
            {
                return Redirect(request.ReturnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<CredentialsResponse> ResolveUserCredentials(LoginDto request)
        {
            try
            {
                UserRequest userRequest = new UserRequest { Username = request.Username };
                return await _grpcUserClient.GetUserCredentialsAsync(userRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in AuthenticationController in GetUserCredentialsAsync {e.Message} in {e.StackTrace}\n InnerException: {e.InnerException}");
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }
        }

        private async Task<CredentialsResponse> VerifyUserPhoneNumberAsync(LoginDto request)
        {
            try
            {
                UserSmsActivationRequest smsActivationRequest = new UserSmsActivationRequest { Username = request.Username, Password = request.Password };
                return await _grpcUserClient.VerifyUserPhoneNumberAsync(smsActivationRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in AuthenticationController in VerifyUserPhoneNumberAsync {e.Message} in {e.StackTrace}\n InnerException: {e.InnerException}");
                throw new BadHttpRequestException("The specified user credentials are invalid.");
            }
        }
    }
}
