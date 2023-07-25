// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Napokon.Customer.API.Constants;
using Napokon.Customer.API.Models;
using Napokon.Customer.API.Models.DTO;
using Napokon.Customer.API.Services.Core;

using Nest;
namespace Napokon.Customer.API.Controllers;

[ApiController]
[Route("api/entity/search")]
public class ExampleEntitySearchController : ControllerBase
{
    private readonly IExampleEntityService _entityService;
    private readonly IElasticSearchService _elasticSearchService;
    private readonly IMapper _mapper;

    public ExampleEntitySearchController(IExampleEntityService entityService, IElasticSearchService elasticSearchService, IMapper mapper)
    {
        _entityService = entityService;
        _elasticSearchService = elasticSearchService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> SearchEntities([FromQuery] PageRequest pageRequest, [FromQuery] string? term = "")
    {
        ISearchResponse<CustomerElasticDto> entities = await _elasticSearchService.SearchAllAsync(pageRequest, term);
        IReadOnlyCollection<CustomerElasticDto> entitiesDocuments = entities.Documents;

        return Ok(_mapper.Map<IReadOnlyCollection<CustomerElasticDto>, List<CustomerDto>>(entitiesDocuments));
    }

    [HttpPut(Endpoints.SEARCH_REINDEX)]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> ElasticSearchReindex()
    {
        PageRequest pageRequest = new PageRequest();
        pageRequest.PerPage = int.MaxValue;

        IList<CustomerEntity> entities = await _entityService.GetAllAsync(pageRequest);
        _elasticSearchService.Reindex(_mapper.Map<IList<CustomerEntity>, IList<CustomerElasticDto>>(entities));

        return Ok();
    }
}

