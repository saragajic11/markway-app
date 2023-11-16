// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.IdentityModel.Tokens;

using Markway.Auth.Configurations;

using Ocelot.DependencyInjection;

namespace Markway.API_Gateway.Middlewares
{
    public static class AuthnMiddleware
    {
        public static AuthenticationConfiguration AddAuthenticationConfiguration(this WebApplicationBuilder builder)
        {
            AuthenticationConfiguration systemConfiguration = new();
            builder.Configuration.Bind(typeof(AuthenticationConfiguration).Name, systemConfiguration);
            builder.Services.AddSingleton(systemConfiguration);

            return systemConfiguration;
        }

        public static void ConfigureAuthentication(this WebApplicationBuilder builder, AuthenticationConfiguration authenticationConfiguration)
        {
            builder.Host
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices(services =>
                {
                    services.AddAuthentication()
                            .AddJwtBearer(options =>
                            {
                                options.Authority = authenticationConfiguration.Jwt.Authority;
                                options.RequireHttpsMetadata = false;
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = false,
                                    ValidateIssuerSigningKey = true,
                                };
                            });
                    services.AddCors(options => {
                        options.AddPolicy(
                                    name: AuthenticationConfiguration.ALLOW_ALL_ORIGIN,
                                    policy => policy.AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .AllowAnyOrigin()
                                            .AllowAnyHeader());
                    });

                    services.AddOcelot();
                });
        }
    }
}

