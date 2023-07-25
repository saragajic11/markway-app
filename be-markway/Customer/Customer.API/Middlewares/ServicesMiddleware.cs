// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Napokon.Commons.Authorization;
using Napokon.Customer.API.Repository;
using Napokon.Customer.API.Repository.Core;
using Napokon.Customer.API.Services;
using Napokon.Customer.API.Services.Core;

namespace Napokon.Customer.API.Middlewares
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

