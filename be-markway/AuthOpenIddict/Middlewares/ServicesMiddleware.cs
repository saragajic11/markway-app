// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

using Markway.AuthOpenIddict.Configurations;
using Markway.Commons.Authorization;

namespace Markway.AuthOpenIddict.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissionOrScopeHandler>();
        }

        public static void AddGrpcClients(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddGrpcClient<UsersService.GrpcUser.GrpcUserClient>(o => o.Address = new Uri(systemConfiguration.GrpcConnections.Users))
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
