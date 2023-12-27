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
public class CarrierController : ControllerBase
{
    private readonly ICarrierService _carrierService;
    private readonly IMapper _mapper;

    public CarrierController(ICarrierService carrierService, IMapper mapper)
    {
        _carrierService = carrierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<Carrier> entities = await _carrierService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<Carrier>, List<CarrierDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        Carrier entity = await _carrierService.GetAsync(id);

        return Ok(_mapper.Map<CarrierDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(CarrierDto entityDto)
    {
        Carrier entity = await _carrierService.AddAsync(entityDto);

        return Ok(_mapper.Map<CarrierDto>(entity));
    }
}
