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
    [Authorize(Policy = Policies.Authorization.SHIPMENT_CREATE)]
    public async Task<IActionResult> GetEntities([FromQuery] ShipmentFilter filter)
    {
        IList<Shipment> entities = await _shipmentService.GetAllAsync(filter);

        return Ok(_mapper.Map<IEnumerable<Shipment>, List<ShipmentDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        Shipment? entity = await _shipmentService.GetAsync(id);

        return Ok(_mapper.Map<ShipmentDto>(entity));
    }

    [HttpDelete("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> DeleteShipment(int id)
    {
        return Ok(await _shipmentService.DeleteAsync(id));
    }

    [HttpPost]
    [Authorize(Policy = Policies.Authorization.SHIPMENT_CREATE)]
    public async Task<IActionResult> CreateEntity(ShipmentDto shipmentDto)
    {
        Shipment? shipment = await _shipmentService.AddAsync(shipmentDto);

        return Ok(_mapper.Map<ShipmentDto>(shipment));
    }

    [HttpPut("status/{id}")]
    [Authorize(Policy = Policies.Authorization.SHIPMENT_CREATE)]
    public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] int statusId)
    {
        return Ok(await _shipmentService.UpdateStatusAsync(id, statusId));
    }

    [HttpPut("{id}")]
    [Authorize(Policy = Policies.Authorization.SHIPMENT_CREATE)]
    public async Task<IActionResult> UpdateShipment([FromRoute] int id, [FromBody] ShipmentDto shipmentDto)
    {
        return Ok(await _shipmentService.UpdateShipmentAsync(id, shipmentDto));
    }
}
