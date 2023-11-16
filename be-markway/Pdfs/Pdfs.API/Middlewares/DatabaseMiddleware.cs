// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Markway.Commons.Configurations;
using Markway.Pdfs.API.Models;

namespace Markway.Pdfs.API.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder, ISystemConfiguration systemConfiguration)
        {
            builder.Services
                .AddDbContext<PdfsContext>(options =>
                {
                    options.UseNpgsql(systemConfiguration.DatabaseConnection);
                });
        }

        public static void ExecuteDatabaseMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                PdfsContext PdfsContext = scope.ServiceProvider.GetRequiredService<PdfsContext>();
                PdfsContext.Database.Migrate();
            }
        }
    }
}

