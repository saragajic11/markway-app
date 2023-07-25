// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Napokon.Commons.Authorization;
using Napokon.Customers.API.Repository;
using Napokon.Customers.API.Repository.Core;
using Napokon.Customers.API.Services;
using Napokon.Customers.API.Services.Core;

namespace Napokon.Customers.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            services.AddScoped<IExampleEntityService, EntityService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

