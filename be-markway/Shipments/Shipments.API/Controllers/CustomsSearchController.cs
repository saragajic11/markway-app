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
public class CustomsSearchController : ControllerBase
{
    private readonly ICustomsService _entityService;
    private readonly ICustomsElasticSearchService _elasticSearchService;
    private readonly IMapper _mapper;

    public CustomsSearchController(ICustomsService entityService, ICustomsElasticSearchService elasticSearchService, IMapper mapper)
    {
        _entityService = entityService;
        _elasticSearchService = elasticSearchService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> SearchEntities([FromQuery] PageRequest pageRequest, [FromQuery] string? term = "")
    {
        ISearchResponse<CustomsElasticDto> entities = await _elasticSearchService.SearchAllAsync(pageRequest, term);
        IReadOnlyCollection<CustomsElasticDto> entitiesDocuments = entities.Documents;

        return Ok(_mapper.Map<IReadOnlyCollection<CustomsElasticDto>, List<CustomsDto>>(entitiesDocuments));
    }

    [HttpPut(Endpoints.SEARCH_REINDEX)]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> ElasticSearchReindex()
    {
        PageRequest pageRequest = new PageRequest();
        pageRequest.PerPage = int.MaxValue;

        IList<Customs> entities = await _entityService.GetAllAsync(pageRequest);
        _elasticSearchService.Reindex(_mapper.Map<IList<Customs>, IList<CustomsElasticDto>>(entities));

        return Ok();
    }
}

