// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.Commons.Authorization;
using Markway.Notification.API.Repository;
using Markway.Notification.API.Repository.Core;
using Markway.Notification.API.Services;
using Markway.Notification.API.Services.Core;

namespace Markway.Notification.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionOrScopeHandler>();

            services.AddScoped<IExampleEntityService, EntityService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

