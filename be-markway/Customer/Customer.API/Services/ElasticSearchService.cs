// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customer.API.Models.DTO;

using Nest;

namespace Napokon.Customer.API.Services.Core
{
    public class ElasticSearchService : IElasticSearchService
    {

        private readonly ILogger _logger;

        private readonly IElasticClient _elasticClient;

        public ElasticSearchService(ILogger<IElasticSearchService> logger, IElasticClient elasticClient)
        {
            _logger = logger;
            _elasticClient = elasticClient;
        }

        public async Task<IndexResponse> IndexDocumentAsync(CustomerElasticDto entityElasticDto)
        {
            return await _elasticClient.IndexDocumentAsync(entityElasticDto);
        }

        public async Task<ISearchResponse<CustomerElasticDto>> SearchAllAsync(PageRequest pageRequest, string term)
        {
            return await _elasticClient.SearchAsync<CustomerElasticDto>(
                    search => search.Query(
                        containerDescriptor => containerDescriptor.QueryString(
                            queryDescriptor => queryDescriptor.Query($"*{term}*")
                        )
                    )
                    .Skip(pageRequest.PerPage * pageRequest.Page)
                    .Size(pageRequest.PerPage)
                    .Sort(query => query.Ascending(entity => entity.Id)));
        }

        public async Task Reindex(IList<CustomerElasticDto> entityElasticDtos)
        {
            _logger.LogWarning("=== Started bulk indexing.");

            BulkResponse bulkResponse = await _elasticClient.IndexManyAsync(entityElasticDtos);

            _logger.LogWarning("=== Finished bulk indexing.");

            _logger.LogWarning("=== Bulk Response Took: {}", bulkResponse.Took);
            _logger.LogWarning("=== Bulk Response Items: {}", bulkResponse.Items.Count);
            _logger.LogWarning("=== Bulk Response Items With Error: {}", bulkResponse.ItemsWithErrors.Count());
        }
    }
}
