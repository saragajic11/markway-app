// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models.DTO;

using Nest;

namespace Markway.Shipments.API.Services.Core
{
    public interface ICarrierElasticSearchService
    {

        Task<IndexResponse> IndexDocumentAsync(CarrierElasticDto entityElasticDto);

        Task<ISearchResponse<CarrierElasticDto>> SearchAllAsync(PageRequest pageRequest, string term);

        Task Reindex(IList<CarrierElasticDto> entityElasticDtos);

    }
}
