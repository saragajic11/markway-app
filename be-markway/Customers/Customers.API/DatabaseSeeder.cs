// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customers.API.Models;
using Napokon.Customers.API.Services.Core;

namespace Napokon.Customers.API
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

            CustomersContext context = scope.ServiceProvider.GetRequiredService<CustomersContext>();
            await context.Database.EnsureCreatedAsync();

            ICustomerService manager = scope.ServiceProvider.GetRequiredService<ICustomerService>();
            // TODO Init some data 
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
