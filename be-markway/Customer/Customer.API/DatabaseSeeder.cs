// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customer.API.Models;
using Napokon.Customer.API.Services.Core;

namespace Napokon.Customer.API
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

            CustomerContext context = scope.ServiceProvider.GetRequiredService<CustomerContext>();
            await context.Database.EnsureCreatedAsync();

            IExampleEntityService manager = scope.ServiceProvider.GetRequiredService<IExampleEntityService>();
            // TODO Init some data 
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
