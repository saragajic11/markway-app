// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Notification.API.Models;
using Markway.Notification.API.Services.Core;

namespace Markway.Notification.API
{
    public class DatabaseSeeder : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseSeeder(
            IServiceProvider serviceProvider
        )
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            NotificationContext context = scope.ServiceProvider.GetRequiredService<NotificationContext>();
            await context.Database.EnsureCreatedAsync();

            IExampleEntityService manager = scope.ServiceProvider.GetRequiredService<IExampleEntityService>();
            // TODO Init some data 
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
