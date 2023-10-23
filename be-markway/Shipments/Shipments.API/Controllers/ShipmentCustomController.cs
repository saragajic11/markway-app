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
public class ShipmentCustomController : ControllerBase
{
    private readonly IShipmentCustomService _shipmentCustomService;
    private readonly IMapper _mapper;

    public ShipmentCustomController(IShipmentCustomService shipmentCustomService, IMapper mapper)
    {
        _shipmentCustomService = shipmentCustomService;;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<ShipmentCustoms> entities = await _shipmentCustomService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<ShipmentCustoms>, List<ShipmentCustomDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        ShipmentCustoms? entity = await _shipmentCustomService.GetAsync(id);

        return Ok(_mapper.Map<ShipmentCustomDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(ShipmentCustomDto shipmentCustomDto)
    {
        ShipmentCustoms? shipmentCustoms = await _shipmentCustomService.AddAsync(shipmentCustomDto);

        return Ok(_mapper.Map<ShipmentCustoms>(shipmentCustomDto));
    }
}
