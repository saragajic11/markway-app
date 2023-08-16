// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Napokon.Shipments.API.Constants;
using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
using Napokon.Shipments.API.Services.Core;

using Nest;
namespace Napokon.Shipments.API.Controllers;

[ApiController]
[Route("api/entity/search")]
public class LoadOnLocationSearchController : ControllerBase
{
    private readonly ILoadOnLocationService _entityService;
    private readonly ILoadOnLocationElasticSearchService _elasticSearchService;
    private readonly IMapper _mapper;

    public LoadOnLocationSearchController(ILoadOnLocationService entityService, ILoadOnLocationElasticSearchService elasticSearchService, IMapper mapper)
    {
        _entityService = entityService;
        _elasticSearchService = elasticSearchService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> SearchEntities([FromQuery] PageRequest pageRequest, [FromQuery] string? term = "")
    {
        ISearchResponse<LoadOnLocationElasticDto> entities = await _elasticSearchService.SearchAllAsync(pageRequest, term);
        IReadOnlyCollection<LoadOnLocationElasticDto> entitiesDocuments = entities.Documents;

        return Ok(_mapper.Map<IReadOnlyCollection<LoadOnLocationElasticDto>, List<LoadOnLocationDto>>(entitiesDocuments));
    }

    [HttpPut(Endpoints.SEARCH_REINDEX)]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> ElasticSearchReindex()
    {
        PageRequest pageRequest = new PageRequest();
        pageRequest.PerPage = int.MaxValue;

        IList<LoadOnLocation> entities = await _entityService.GetAllAsync(pageRequest);
        _elasticSearchService.Reindex(_mapper.Map<IList<LoadOnLocation>, IList<LoadOnLocationElasticDto>>(entities));

        return Ok();
    }
}

