// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Markway.Commons.Authorization;
using Markway.Commons.Configurations;
using Markway.Users.API.Constants;

namespace Markway.Users.API.Middlewares
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
                        PermissionOrScopeRequirement requirement = new(new List<string>() { "Permissions.ExampleEntity.Action" }, null);
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

