// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Napokon.Commons.Authorization;
using Napokon.Shipments.API.Repository;
using Napokon.Shipments.API.Repository.Core;
using Napokon.Shipments.API.Services;
using Napokon.Shipments.API.Services.Core;

namespace Napokon.Shipments.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarrierService, CarrierService>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

