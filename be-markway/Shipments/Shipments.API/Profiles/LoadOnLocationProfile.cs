// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;

namespace Napokon.Shipments.API.Profiles
{
    public class LoadOnLocationProfile : Profile
    {
        public LoadOnLocationProfile()
        {
            CreateMap<LoadOnLocation, LoadOnLocationDto>();

            CreateMap<LoadOnLocationDto, LoadOnLocation>();

            CreateMap<LoadOnLocation, LoadOnLocationElasticDto>();

            CreateMap<LoadOnLocationElasticDto, LoadOnLocationDto>();
        }
    }
}

