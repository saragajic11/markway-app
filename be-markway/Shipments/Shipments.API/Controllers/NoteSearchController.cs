// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Markway.Shipments.API.Constants;
using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Services.Core;

using Nest;
namespace Markway.Shipments.API.Controllers;

[ApiController]
[Route("api/entity/search")]
public class NoteSearchController : ControllerBase
{
    private readonly INoteService _entityService;
    private readonly INoteElasticSearchService _elasticSearchService;
    private readonly IMapper _mapper;

    public NoteSearchController(INoteService entityService, INoteElasticSearchService elasticSearchService, IMapper mapper)
    {
        _entityService = entityService;
        _elasticSearchService = elasticSearchService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> SearchEntities([FromQuery] PageRequest pageRequest, [FromQuery] string? term = "")
    {
        ISearchResponse<NoteElasticDto> entities = await _elasticSearchService.SearchAllAsync(pageRequest, term);
        IReadOnlyCollection<NoteElasticDto> entitiesDocuments = entities.Documents;

        return Ok(_mapper.Map<IReadOnlyCollection<NoteElasticDto>, List<NoteDto>>(entitiesDocuments));
    }

    [HttpPut(Endpoints.SEARCH_REINDEX)]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> ElasticSearchReindex()
    {
        PageRequest pageRequest = new PageRequest();
        pageRequest.PerPage = int.MaxValue;

        IList<Note> entities = await _entityService.GetAllAsync(pageRequest);
        _elasticSearchService.Reindex(_mapper.Map<IList<Note>, IList<NoteElasticDto>>(entities));

        return Ok();
    }
}

