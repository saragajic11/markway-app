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
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<Customer> entities = await _customerService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<Customer>, List<CustomerDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        Customer? entity = await _customerService.GetAsync(id);

        return Ok(_mapper.Map<CustomerDto>(entity));
    }

    [HttpPost(Name = "CreateEntity")]
    public async Task<IActionResult> CreateEntity(CustomerDto customerDto)
    {
        Customer? customer = await _customerService.AddAsync(customerDto);

        return Ok(_mapper.Map<CustomerDto>(customer));
    }
}
