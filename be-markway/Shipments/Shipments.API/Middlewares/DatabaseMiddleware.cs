// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Markway.Commons.Configurations;
using Markway.Shipments.API.Models;

namespace Markway.Shipments.API.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            Console.WriteLine($"{systemConfiguration.DatabaseConnection}");

            builder.Services
                .AddDbContext<ShipmentsContext>(options => options.UseNpgsql(systemConfiguration.DatabaseConnection));
        }

        public static void ExecuteDatabaseMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                ShipmentsContext ShipmentsContext = scope.ServiceProvider.GetRequiredService<ShipmentsContext>();
                ShipmentsContext.Database.Migrate();
            }
        }
    }
}

