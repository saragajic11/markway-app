// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Napokon.Customer.API.Constants;
using Napokon.Customer.API.Models;
using Napokon.Customer.API.Models.DTO;
using Napokon.Customer.API.Services.Core;
namespace Napokon.Customer.API.Controllers;

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
        IList<CustomerEntity> entities = await _entityService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<CustomerEntity>, List<CustomerDto>>(entities));
    }

    [HttpGet("{id}")]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        CustomerEntity entity = await _entityService.GetAsync(id);

        return Ok(_mapper.Map<CustomerDto>(entity));
    }

    [HttpPost(Name = "CreateEntity")]
    public async Task<IActionResult> CreateEntity(CustomerDto entityDto)
    {
        CustomerEntity entity = await _entityService.AddAsync(entityDto);

        return Ok(_mapper.Map<CustomerDto>(entity));
    }
}

