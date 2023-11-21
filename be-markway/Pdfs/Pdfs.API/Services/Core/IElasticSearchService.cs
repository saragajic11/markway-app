// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Pdfs.API.Models.DTO;

using Nest;

namespace Markway.Pdfs.API.Services.Core
{
    public interface IElasticSearchService
    {

        Task<IndexResponse> IndexDocumentAsync(ExampleEntityElasticDto entityElasticDto);

        Task<ISearchResponse<ExampleEntityElasticDto>> SearchAllAsync(PageRequest pageRequest, string term);

        Task Reindex(IList<ExampleEntityElasticDto> entityElasticDtos);

    }
}
