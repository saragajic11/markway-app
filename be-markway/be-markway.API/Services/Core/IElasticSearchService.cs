﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.be_markway.API.Models.DTO;

using Nest;

namespace Napokon.be_markway.API.Services.Core
{
    public interface IElasticSearchService
    {

        Task<IndexResponse> IndexDocumentAsync(ExampleEntityElasticDto entityElasticDto);

        Task<ISearchResponse<ExampleEntityElasticDto>> SearchAllAsync(PageRequest pageRequest, string term);

        Task Reindex(IList<ExampleEntityElasticDto> entityElasticDtos);

    }
}
