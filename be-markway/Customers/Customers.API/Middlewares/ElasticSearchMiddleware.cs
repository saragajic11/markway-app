// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Commons.Configurations;
using Napokon.Customers.API.Models.DTO;

using Nest;

namespace Napokon.Customers.API.Middlewares
{
    public static class ElasticSearchMiddleware
    {
        public static void ConfigureElasticSearch(this IServiceCollection services, ISystemConfiguration _systemConfiguration)
        {
            string defaultIndex = _systemConfiguration.ELKConfiguration.DefaultIndex;

            ConnectionSettings settings = new ConnectionSettings(new Uri(_systemConfiguration.ELKConfiguration.Uri))
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            ElasticClient client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            if (!client.Indices.Exists(indexName).Exists)
            {
                CreateIndexResponse CreateIndexResponse = client.Indices.Create(indexName, index => index.Map<CustomerDto>(x => x.AutoMap()));
            }
        }
    }
}
