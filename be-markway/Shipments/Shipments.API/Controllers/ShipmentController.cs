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
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _shipmentService;
    private readonly IMapper _mapper;

    public ShipmentController(IShipmentService shipmentService, IMapper mapper)
    {
        _shipmentService = shipmentService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<Shipment> entities = await _shipmentService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<Shipment>, List<ShipmentDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        Shipment? entity = await _shipmentService.GetAsync(id);

        return Ok(_mapper.Map<ShipmentDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(ShipmentDto shipmentDto)
    {
        Shipment? shipment = await _shipmentService.AddAsync(shipmentDto);

        return Ok(_mapper.Map<ShipmentDto>(shipmentDto));
    }
}
