// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Markway.AuthOpenIddict.Configurations;
using Markway.AuthOpenIddict.Models;

namespace Markway.AuthOpenIddict.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddDbContext<AuthnServerDbContext>(options =>
                {
                    options.UseNpgsql(systemConfiguration.DatabaseConnection);
                    options.UseOpenIddict();
                });
        }

        public static void ExecuteDatabaseMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                AuthnServerDbContext authnServerDbContext = scope.ServiceProvider.GetRequiredService<AuthnServerDbContext>();
                authnServerDbContext.Database.Migrate();
            }
        }
    }
}

