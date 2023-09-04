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
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly IMapper _mapper;

    public NoteController(INoteService noteService, IMapper mapper)
    {
        _noteService = noteService;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntities([FromQuery] PageRequest pageRequest)
    {
        IList<Note> entities = await _noteService.GetAllAsync(pageRequest);

        return Ok(_mapper.Map<IEnumerable<Note>, List<NoteDto>>(entities));
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
    public async Task<IActionResult> GetEntityById(int id)
    {
        Note? entity = await _noteService.GetAsync(id);

        return Ok(_mapper.Map<NoteDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity(NoteDto noteDto)
    {
        Note? note = await _noteService.AddAsync(noteDto);

        return Ok(_mapper.Map<NoteDto>(note));
    }
}
