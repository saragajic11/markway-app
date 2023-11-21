// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Markway.Users.API.Constants;
using Markway.Users.API.Models;
using Markway.Users.API.Models.DTO;
using Markway.Users.API.Services.Core;
namespace Markway.Users.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService entityService, IMapper mapper)
    {
        _userService = entityService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<User> entities = await _userService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<User>, List<UserDto>>(entities));
    }

    [HttpGet("{id}")]
    [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        User entity = await _userService.GetAsync(id);

        return Ok(_mapper.Map<UserDto>(entity));
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        User? user = await _userService.AddAsync(userDto);

        return Ok(_mapper.Map<UserDto>(user));
    }
}