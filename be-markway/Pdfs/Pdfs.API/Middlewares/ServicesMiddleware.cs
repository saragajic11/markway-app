// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.Commons.Authorization;
using Markway.Pdfs.API.Repository;
using Markway.Pdfs.API.Repository.Core;
using Markway.Pdfs.API.Services;
using Markway.Pdfs.API.Services.Core;

namespace Markway.Pdfs.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionOrScopeHandler>();

            services.AddScoped<IExampleEntityService, PdfService>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

