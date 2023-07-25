// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Napokon.Microservice.API.Constants;
using Napokon.Microservice.API.Models;
using Napokon.Microservice.API.Models.DTO;
using Napokon.Microservice.API.Services.Core;
namespace Napokon.Microservice.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleEntityController : ControllerBase
{
    private readonly IExampleEntityService _entityService;
    private readonly IMapper _mapper;

    public ExampleEntityController(IExampleEntityService entityService, IMapper mapper)
    {
        _entityService = entityService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<ExampleEntity> entities = await _entityService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<ExampleEntity>, List<ExampleEntityDto>>(entities));
    }

    [HttpGet("{id}")]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        ExampleEntity entity = await _entityService.GetAsync(id);

        return Ok(_mapper.Map<ExampleEntityDto>(entity));
    }

    [HttpPost(Name = "CreateEntity")]
    public async Task<IActionResult> CreateEntity(ExampleEntityDto entityDto)
    {
        ExampleEntity entity = await _entityService.AddAsync(entityDto);

        return Ok(_mapper.Map<ExampleEntityDto>(entity));
    }
}

