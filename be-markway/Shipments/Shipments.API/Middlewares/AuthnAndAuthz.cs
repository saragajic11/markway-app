// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Markway.Commons.Authorization;
using Markway.Commons.Configurations;
using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Middlewares
{
    public static class AuthnAndAuthzMiddleware
    {
        public static void AddAuthenticationAndAuthorization(this IServiceCollection services, ISystemConfiguration systemConfiguration)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(Policies.Authorization.ACTION_ENTITY_NAME, policyBuilder =>
                    {
                        PermissionRequirement requirement = new(new List<string>() { "Permissions.ExampleEntity.Action" });
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

