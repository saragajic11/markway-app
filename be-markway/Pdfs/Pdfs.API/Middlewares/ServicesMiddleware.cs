// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.Commons.Authorization;
using Markway.Pdfs.API.Repository;
using Markway.Pdfs.API.Repository.Core;
using Markway.Pdfs.API.Services;
using Markway.Pdfs.API.Services.Core;
using static UsersService.GrpcUser;
using Markway.Commons.Configurations;
using Markway.Pdfs.API.Services.Grpc.Clients;
using static Markway.Notification.API.Grpc.GrpcEmail;

namespace Markway.Pdfs.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();
            services.AddHttpContextAccessor();

            services.AddSingleton<IAuthorizationHandler, PermissionOrScopeHandler>();

            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();
            services.AddScoped<IUserClient, UserClient>();
            services.AddScoped<INotificationClient, NotificationClient>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddGrpcClients(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddGrpcClient<GrpcUserClient>(o => o.Address = new Uri(systemConfiguration.GrpcConnections.User))
                .ConfigureChannel(o =>
                {
                    o.UnsafeUseInsecureChannelCallCredentials = true;
                    HttpClientHandler httpHandler = new();
                    httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    o.HttpHandler = httpHandler;
                });
            builder.Services
                .AddGrpcClient<GrpcEmailClient>(o => o.Address = new Uri(systemConfiguration.GrpcConnections.Notification))
                .ConfigureChannel(o =>
                {
                    o.UnsafeUseInsecureChannelCallCredentials = true;
                    HttpClientHandler httpHandler = new();
                    httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    o.HttpHandler = httpHandler;
                });
        }
    }
}