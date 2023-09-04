// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Microservice.API.Models.DTO;

using Nest;

namespace Markway.Microservice.API.Services.Core
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

        public async Task<IndexResponse> IndexDocumentAsync(ExampleEntityElasticDto entityElasticDto)
        {
            return await _elasticClient.IndexDocumentAsync(entityElasticDto);
        }

        public async Task<ISearchResponse<ExampleEntityElasticDto>> SearchAllAsync(PageRequest pageRequest, string term)
        {
            return await _elasticClient.SearchAsync<ExampleEntityElasticDto>(
                    search => search.Query(
                        containerDescriptor => containerDescriptor.QueryString(
                            queryDescriptor => queryDescriptor.Query($"*{term}*")
                        )
                    )
                    .Skip(pageRequest.PerPage * pageRequest.Page)
                    .Size(pageRequest.PerPage)
                    .Sort(query => query.Ascending(entity => entity.Id)));
        }

        public async Task Reindex(IList<ExampleEntityElasticDto> entityElasticDtos)
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
