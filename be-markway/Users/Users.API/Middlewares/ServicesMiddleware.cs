// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.Commons.Authorization;
using Markway.Users.API.Repository;
using Markway.Users.API.Repository.Core;
using Markway.Users.API.Services;
using Markway.Users.API.Services.Core;
using Markway.Commons.Configurations;

namespace Markway.Users.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionOrScopeHandler>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddGrpcClients(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
        }
    }
}
