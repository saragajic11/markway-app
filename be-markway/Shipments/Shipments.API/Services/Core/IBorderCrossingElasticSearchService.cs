// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models.DTO;

using Nest;

namespace Napokon.Shipments.API.Services.Core
{
    public interface IBorderCrossingElasticSearchService
    {

        Task<IndexResponse> IndexDocumentAsync(BorderCrossingElasticDto entityElasticDto);

        Task<ISearchResponse<BorderCrossingElasticDto>> SearchAllAsync(PageRequest pageRequest, string term);

        Task Reindex(IList<BorderCrossingElasticDto> entityElasticDtos);

    }
}