// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Napokon.Customers.API.Constants;
using Napokon.Customers.API.Models;
using Napokon.Customers.API.Models.DTO;
using Napokon.Customers.API.Services.Core;

using Nest;
namespace Napokon.Customers.API.Controllers;

[ApiController]
[Route("api/entity/search")]
public class CustomerSearchController : ControllerBase
{
    private readonly ICustomerService _entityService;
    private readonly IMapper _mapper;

    public CustomerSearchController(ICustomerService entityService, IMapper mapper)
    {
        _entityService = entityService;
        _mapper = mapper;
    }
}

