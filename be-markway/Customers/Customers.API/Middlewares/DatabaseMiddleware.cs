// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Napokon.Commons.Configurations;
using Napokon.Customers.API.Models;

namespace Napokon.Customers.API.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddDbContext<CustomersContext>(options =>
                {
                    options.UseNpgsql(systemConfiguration.DatabaseConnection);
                });
        }

        public static void ExecuteDatabaseMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                CustomersContext CustomersContext = scope.ServiceProvider.GetRequiredService<CustomersContext>();
                CustomersContext.Database.Migrate();
            }
        }
    }
}

