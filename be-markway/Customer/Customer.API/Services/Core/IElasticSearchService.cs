// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customer.API.Models.DTO;

using Nest;

namespace Napokon.Customer.API.Services.Core
{
    public interface IElasticSearchService
    {

        Task<IndexResponse> IndexDocumentAsync(CustomerElasticDto entityElasticDto);

        Task<ISearchResponse<CustomerElasticDto>> SearchAllAsync(PageRequest pageRequest, string term);

        Task Reindex(IList<CustomerElasticDto> entityElasticDtos);

    }
}
