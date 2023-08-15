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
public class ExampleEntitySearchController : ControllerBase
{
    private readonly ICustomerService _entityService;
    private readonly IElasticSearchService _elasticSearchService;
    private readonly IMapper _mapper;

    public ExampleEntitySearchController(ICustomerService entityService, IElasticSearchService elasticSearchService, IMapper mapper)
    {
        _entityService = entityService;
        _elasticSearchService = elasticSearchService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> SearchEntities([FromQuery] PageRequest pageRequest, [FromQuery] string? term = "")
    {
        ISearchResponse<ExampleEntityElasticDto> entities = await _elasticSearchService.SearchAllAsync(pageRequest, term);
        IReadOnlyCollection<ExampleEntityElasticDto> entitiesDocuments = entities.Documents;

        return Ok(_mapper.Map<IReadOnlyCollection<ExampleEntityElasticDto>, List<CustomerDto>>(entitiesDocuments));
    }

    [HttpPut(Endpoints.SEARCH_REINDEX)]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> ElasticSearchReindex()
    {
        PageRequest pageRequest = new PageRequest();
        pageRequest.PerPage = int.MaxValue;

        IList<Customer> entities = await _entityService.GetAllAsync(pageRequest);
        _elasticSearchService.Reindex(_mapper.Map<IList<Customer>, IList<ExampleEntityElasticDto>>(entities));

        return Ok();
    }
}

