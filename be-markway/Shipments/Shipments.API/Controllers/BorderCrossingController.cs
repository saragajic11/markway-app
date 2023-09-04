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
public class BorderCrossingController : ControllerBase
{
    private readonly IBorderCrossingService _borderCrossingService;
    private readonly IMapper _mapper;

    public BorderCrossingController(IBorderCrossingService borderCrossingService, IMapper mapper)
    {
        _borderCrossingService = borderCrossingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<BorderCrossing> entities = await _borderCrossingService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<BorderCrossing>, List<BorderCrossingDto>>(entities));
    }

    [HttpGet("{id}")]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        BorderCrossing entity = await _borderCrossingService.GetAsync(id);

        return Ok(_mapper.Map<BorderCrossingDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(BorderCrossingDto entityDto)
    {
        BorderCrossing entity = await _borderCrossingService.AddAsync(entityDto);

        return Ok(_mapper.Map<BorderCrossingDto>(entity));
    }
}
