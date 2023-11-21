// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Users.API.Models;
using Markway.Users.API.Services.Core;

namespace Markway.Users.API
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

            UsersContext context = scope.ServiceProvider.GetRequiredService<UsersContext>();
            await context.Database.EnsureCreatedAsync();

            IUserService manager = scope.ServiceProvider.GetRequiredService<IUserService>();
            // TODO Init some data 
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
