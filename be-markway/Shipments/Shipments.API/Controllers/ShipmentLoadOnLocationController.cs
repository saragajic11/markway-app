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
public class ShipmentLoadOnLocationController : ControllerBase
{
    private readonly IShipmentLoadOnLocationService _shipmentLoadOnLocationService;
    private readonly IMapper _mapper;

    public ShipmentLoadOnLocationController(IShipmentLoadOnLocationService shipmentLoadOnLocationService, IMapper mapper)
    {
        _shipmentLoadOnLocationService = shipmentLoadOnLocationService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<ShipmentLoadOnLocation> entities = await _shipmentLoadOnLocationService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<ShipmentLoadOnLocation>, List<ShipmentLoadOnLocationDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        ShipmentLoadOnLocation? entity = await _shipmentLoadOnLocationService.GetAsync(id);

        return Ok(_mapper.Map<ShipmentLoadOnLocationDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(ShipmentLoadOnLocationDto shipmentLoadOnLocationDto)
    {
        ShipmentLoadOnLocation? shipmentLoadOnLocation = await _shipmentLoadOnLocationService.AddAsync(shipmentLoadOnLocationDto);

        return Ok(_mapper.Map<ShipmentLoadOnLocation>(shipmentLoadOnLocationDto));
    }

    [HttpGet("getByShipment")]
    public async Task<IActionResult> GetAsyncByShipmentId([FromQuery] long shipmentId)
    {
        IList<ShipmentLoadOnLocation?> shipmentLoadOnLocations = await _shipmentLoadOnLocationService.GetAsyncByShipmentId(shipmentId);
        return Ok(_mapper.Map<IList<ShipmentLoadOnLocation>, List<ShipmentLoadOnLocationDto>>(shipmentLoadOnLocations));
    }

    [HttpGet("getByShipmentAndType")]
    public async Task<IActionResult> GetAsyncByShipmentIdAndLoadOnLocationType([FromQuery] long shipmentId, [FromQuery] long type)
    {
        IList<ShipmentLoadOnLocation?> shipmentLoadOnLocations = await _shipmentLoadOnLocationService.GetAsyncByShipmentIdAndLoadOnLocationType(shipmentId, type);
        return Ok(_mapper.Map<IList<ShipmentLoadOnLocation>, List<ShipmentLoadOnLocationDto>>(shipmentLoadOnLocations));
    }
}
