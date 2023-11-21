// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Markway.Commons.Configurations;
using Markway.Users.API.Models;

namespace Markway.Users.API.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddDbContext<UsersContext>(options =>
                {
                    options.UseNpgsql(systemConfiguration.DatabaseConnection);
                });
        }

        public static void ExecuteDatabaseMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                UsersContext UsersContext = scope.ServiceProvider.GetRequiredService<UsersContext>();
                UsersContext.Database.Migrate();
            }
        }
    }
}

