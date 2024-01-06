// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Markway.Commons.Configurations;
using Markway.Notification.API.Models;

namespace Markway.Notification.API.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddDbContext<NotificationContext>(options =>
                {
                    options.UseNpgsql(systemConfiguration.DatabaseConnection);
                });
        }

        public static void ExecuteDatabaseMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                NotificationContext NotificationContext = scope.ServiceProvider.GetRequiredService<NotificationContext>();
                NotificationContext.Database.Migrate();
            }
        }
    }
}

