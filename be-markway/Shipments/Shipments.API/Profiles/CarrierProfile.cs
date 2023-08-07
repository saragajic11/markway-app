// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;

namespace Napokon.Shipments.API.Profiles
{
    public class CarrierProfile : Profile
    {
        public CarrierProfile()
        {
            CreateMap<Carrier, CarrierDto>();

            CreateMap<CarrierDto, Carrier>();

            CreateMap<Carrier, CarrierElasticDto>();

            CreateMap<CarrierElasticDto, CarrierDto>();
        }
    }
}

