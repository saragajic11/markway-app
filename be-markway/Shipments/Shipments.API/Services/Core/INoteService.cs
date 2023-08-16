// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
namespace Napokon.Shipments.API.Services.Core
{
    public interface INoteService
    {
        Task<Note?> AddAsync(NoteDto dto);

        Task<IList<Note>> GetAllAsync(PageRequest pageRequest);

        Task<Note?> GetAsync(long id);
    }
}
