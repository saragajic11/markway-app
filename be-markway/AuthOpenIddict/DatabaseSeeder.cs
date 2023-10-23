// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.AuthOpenIddict.Models;

using OpenIddict.Abstractions;

using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Markway.AuthOpenIddict
{
    public class DatabaseSeeder : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public DatabaseSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            AuthnServerDbContext context = scope.ServiceProvider.GetRequiredService<AuthnServerDbContext>();
            await context.Database.EnsureCreatedAsync();

            IOpenIddictApplicationManager manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
            if (await
                manager.FindByClientIdAsync("m2m_app") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "m2m_app",
                    ClientSecret = "b/pcB1CXw5NZqfNE1uz2Ozgqjzw3hrV+",
                    DisplayName = "Markway M2M App",
                    Permissions =
                {
                    Permissions.Endpoints.Token,

                    Permissions.GrantTypes.ClientCredentials,
                    Permissions.GrantTypes.RefreshToken,

                    Permissions.Prefixes.Scope + ".api"
                }
                });
            }

            if (await manager.FindByClientIdAsync("webapp") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "webapp",
                    DisplayName = "Markway Web App",
                    RedirectUris = { new Uri("https://oauth.pstmn.io/v1/callback") },
                    Permissions =
                {
                    Permissions.Endpoints.Authorization,
                    Permissions.Endpoints.Token,

                    Permissions.GrantTypes.RefreshToken,
                    Permissions.GrantTypes.AuthorizationCode,
                    Permissions.GrantTypes.Password,

                    Permissions.Prefixes.Scope + ".api",
                    Permissions.ResponseTypes.Code
                },
                    Requirements =
                {
                    Requirements.Features.ProofKeyForCodeExchange
                }
                });
            }

            if (await manager.FindByClientIdAsync("native_app") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "native_app",
                    DisplayName = "Markway Native App",
                    RedirectUris = { new Uri("https://markway/callback"), new Uri("markway://calback") },
                    Permissions =
                {
                    Permissions.Endpoints.Authorization,
                    Permissions.Endpoints.Token,

                    Permissions.GrantTypes.RefreshToken,
                    Permissions.GrantTypes.AuthorizationCode,
                    Permissions.GrantTypes.Password,

                    Permissions.Prefixes.Scope + "api",
                    Permissions.ResponseTypes.Code
                },
                    Requirements =
                {
                    Requirements.Features.ProofKeyForCodeExchange
                }
                });
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

