// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;

namespace Napokon.Shipments.API.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDto>();

            CreateMap<NoteDto, Note>();

            CreateMap<Note, NoteElasticDto>();

            CreateMap<NoteElasticDto, NoteDto>();
        }
    }
}

