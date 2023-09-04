// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Markway.Shipments.API.Constants;
using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoadOnLocationController : ControllerBase
{
    private readonly ILoadOnLocationService _loadOnLocationService;
    private readonly IMapper _mapper;

    public LoadOnLocationController(ILoadOnLocationService loadOnLocationService, IMapper mapper)
    {
        _loadOnLocationService = loadOnLocationService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<LoadOnLocation> entities = await _loadOnLocationService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<LoadOnLocation>, List<LoadOnLocationDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        LoadOnLocation? entity = await _loadOnLocationService.GetAsync(id);

        return Ok(_mapper.Map<LoadOnLocationDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(LoadOnLocationDto loadOnLocationDto)
    {
        LoadOnLocation? loadOnLocation = await _loadOnLocationService.AddAsync(loadOnLocationDto);

        return Ok(_mapper.Map<LoadOnLocationDto>(loadOnLocation));
    }
}
