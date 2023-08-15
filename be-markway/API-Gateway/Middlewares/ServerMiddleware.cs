// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Auth.Configurations;

namespace Napokon.API_Gateway.Middlewares
{
    public static class ServerMiddleware
    {

        public static void ConfigureAppConfiguration(this WebApplicationBuilder builder)
        {
            builder.Host
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddJsonFile("ocelot.json")
                        .AddEnvironmentVariables();
                });
        }

        public static void ConfigureCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options => {
                options.AddPolicy(
                    name: AuthenticationConfiguration.ALLOW_ALL_ORIGIN,
                    policy => policy.AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyHeader());
            });
        }
    }
}

