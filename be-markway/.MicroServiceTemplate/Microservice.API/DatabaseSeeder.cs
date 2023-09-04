// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Microservice.API.Models;
using Markway.Microservice.API.Services.Core;

namespace Markway.Microservice.API
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

            MicroserviceContext context = scope.ServiceProvider.GetRequiredService<MicroserviceContext>();
            await context.Database.EnsureCreatedAsync();

            IExampleEntityService manager = scope.ServiceProvider.GetRequiredService<IExampleEntityService>();
            // TODO Init some data 
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
