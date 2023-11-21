// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Markway.Commons.Authorization;
using Markway.Commons.Configurations;
using Markway.Pdfs.API.Constants;

namespace Markway.Pdfs.API.Middlewares
{
    public static class AuthnAndAuthzMiddleware
    {
        public static void AddAuthenticationAndAuthorization(this IServiceCollection services, ISystemConfiguration systemConfiguration)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(Policies.Authorization.FILE_CREATE, policyBuilder =>
                    {
                        PermissionOrScopeRequirement requirement = new(new List<string>() { Permissions.S3Files.CREATE }, null);
                        policyBuilder.AddRequirements(requirement);
                    });
                })
                .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                    {
                        options.Authority = systemConfiguration.Jwt.Authority;
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(systemConfiguration.Jwt.TokenValidation.Key)),
                            ValidateIssuer = true,
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = false,
                            ClockSkew = TimeSpan.Zero
                        };
                    });
        }
    }
}
