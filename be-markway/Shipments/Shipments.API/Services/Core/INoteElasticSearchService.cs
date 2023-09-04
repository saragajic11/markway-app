// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models.DTO;

using Nest;

namespace Markway.Shipments.API.Services.Core
{
    public interface INoteElasticSearchService
    {

        Task<IndexResponse> IndexDocumentAsync(NoteDto entityElasticDto);

        Task<ISearchResponse<NoteElasticDto>> SearchAllAsync(PageRequest pageRequest, string term);

        Task Reindex(IList<NoteElasticDto> entityElasticDtos);

    }
}
