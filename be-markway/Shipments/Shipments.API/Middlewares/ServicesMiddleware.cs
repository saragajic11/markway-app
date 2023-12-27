// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.Commons.Authorization;
using Markway.Shipments.API.Repository;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services;
using Markway.Shipments.API.Services.Core;
using Markway.Commons.Configurations;
using Markway.Shipments.API.Services.Grpc.Clients;
using static UsersService.GrpcUser;

namespace Markway.Shipments.API.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseSeeder>();

            services.AddSingleton<IAuthorizationHandler, PermissionOrScopeHandler>();
            services.AddHttpContextAccessor();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarrierService, CarrierService>();
            services.AddScoped<IBorderCrossingService, BorderCrossingService>();
            services.AddScoped<ICustomsService, CustomsService>();
            services.AddScoped<ILoadOnLocationService, LoadOnLocationService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IShipmentLoadOnLocationService, ShipmentLoadOnLocationService>();
            services.AddScoped<IShipmentCustomService, ShipmentCustomService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IUserClient, UserClient>();

            services.AddScoped<IElasticSearchService, ElasticSearchService>();

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
        }
    }
}