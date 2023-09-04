// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Server.Kestrel.Core;

using Markway.Commons.Configurations;
using Markway.Microservice.API.Constants;

namespace Markway.Microservice.API.Middlewares
{
    public static class ServerMiddleware
    {

        public static ISystemConfiguration AddSystemConfiguration(this WebApplicationBuilder builder)
        {
            SystemConfiguration systemConfiguration = new();
            builder.Configuration.Bind(typeof(SystemConfiguration).Name, systemConfiguration);
            builder.Services.AddSingleton(systemConfiguration);

            return systemConfiguration;
        }

        public static void ConfigureCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options => {
                options.AddPolicy(
                            name: Policies.CORS.ALLOW_ALL_ORIGIN,
                            policy => policy.AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader());
            });
        }

        public static void ConfigureKestrel(this WebApplicationBuilder builder)
        {
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5287, o =>
                {
                    o.Protocols = HttpProtocols.Http2;
                });
                options.ListenAnyIP(5387, o =>
                {
                    o.Protocols = HttpProtocols.Http1;
                });
            });
        }
    }
}

