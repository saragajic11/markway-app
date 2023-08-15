// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Napokon.Shipments.API.Constants;
using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
using Napokon.Shipments.API.Services.Core;
namespace Napokon.Shipments.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomsController : ControllerBase
{
    private readonly ICustomsService _customsService;
    private readonly IMapper _mapper;

    public CustomsController(ICustomsService customsService, IMapper mapper)
    {
        _customsService = customsService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<Customs> entities = await _customsService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<Customs>, List<CustomsDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        Customs? entity = await _customsService.GetAsync(id);

        return Ok(_mapper.Map<CustomsDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(CustomsDto customsDto)
    {
        Customs? customs = await _customsService.AddAsync(customsDto);

        return Ok(_mapper.Map<CustomsDto>(customs));
    }
}
