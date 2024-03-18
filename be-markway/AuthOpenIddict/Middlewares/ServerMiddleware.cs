// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;

using Markway.AuthOpenIddict.Configurations;
using Markway.AuthOpenIddict.Constants;
using Markway.AuthOpenIddict.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Markway.AuthOpenIddict.Middlewares
{
    public static class ServerMiddleware
    {
        public static ISystemConfiguration AddSystemConfiguration(this WebApplicationBuilder builder)
        {
            SystemConfiguration systemConfiguration = new();
            builder.Configuration.Bind(typeof(SystemConfiguration).Name, systemConfiguration);
            builder.Services.AddSingleton(systemConfiguration);

            return systemConfiguration;
        }

        public static void ConfigureKestrel(this WebApplicationBuilder builder)
        {
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5253, o => o.Protocols = HttpProtocols.Http2);
                options.ListenAnyIP(5353, o =>
                {
                    o.Protocols = HttpProtocols.Http1;
                });
            });
        }

        public static void ConfigureOpenIdConnect(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => options.LoginPath = Endpoints.LOGIN);

            builder.Services
                .AddOpenIddict()
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default entities.
                    options.UseEntityFrameworkCore()
                        .UseDbContext<AuthnServerDbContext>();
                })
                .AddServer(options =>
                {
                    // Enable the token endpoint.
                    options
                        .SetAuthorizationEndpointUris(Endpoints.AUTHORIZE)
                        .SetTokenEndpointUris(Endpoints.TOKEN, Endpoints.ADMIN_TOKEN, Endpoints.ANONYMOUS_TOKEN)
                        .SetUserinfoEndpointUris(Endpoints.USER_INFO);

                    // Enable the client credentials flow.
                    options
                        .AllowAuthorizationCodeFlow()
                            .RequireProofKeyForCodeExchange()
                        .AllowClientCredentialsFlow()
                        .AllowPasswordFlow()
                        .AllowRefreshTokenFlow()
                        .SetAccessTokenLifetime(TimeSpan.FromDays(14))
                        .SetRefreshTokenLifetime(TimeSpan.FromDays(28));

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                        .AddDevelopmentSigningCertificate()
                        .AddEncryptionKey(new SymmetricSecurityKey(Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")))
                        .DisableAccessTokenEncryption();

                    // Register the ASP.NET Core host and configure the ASP.NET Core options.
                    options.UseAspNetCore()
                        .EnableTokenEndpointPassthrough()
                        .EnableAuthorizationEndpointPassthrough()
                        .EnableUserinfoEndpointPassthrough();

                    options
                        .UseAspNetCore()
                        .DisableTransportSecurityRequirement();

                    options.UseDataProtection()
                        .PreferDefaultAccessTokenFormat()
                        .PreferDefaultAuthorizationCodeFormat()
                        .PreferDefaultDeviceCodeFormat()
                        .PreferDefaultRefreshTokenFormat()
                        .PreferDefaultUserCodeFormat();
                })
                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();

                    //options.Configure(options => options.TokenValidationParameters.IssuerSigningKey =
                    //    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("igFTChjDtHbHvW7ayWxILiL50n8DcgeQ")));

                    //options.UseDataProtection();

                    //options.SetIssuer("https://localhost:7013/");
                    //options.AddAudiences("console");
                    //options.SetClientId("console");
                    //options.SetClientSecret("388D45FA-B36B-4988-BA59-B187D329C207");
                    //options.UseIntrospection();
                    //options.UseSystemNetHttp();
                });
        }
    }
}
