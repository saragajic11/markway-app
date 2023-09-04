// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.Commons.Authorization;
using Markway.Microservice.API.Repository;
using Markway.Microservice.API.Repository.Core;
using Markway.Microservice.API.Services;
using Markway.Microservice.API.Services.Core;

namespace Markway.Microservice.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            services.AddScoped<IExampleEntityService, EntityService>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

