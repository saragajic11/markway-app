// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;

namespace Markway.Shipments.API.Profiles
{
    public class ShipmentCustomProfile : Profile
    {
        public ShipmentCustomProfile()
        {
            CreateMap<ShipmentCustoms, ShipmentCustomDto>();

            CreateMap<ShipmentCustomDto, ShipmentCustoms>();

            CreateMap<ShipmentCustoms, ShipmentCustomElasticDto>();

            CreateMap<ShipmentCustomElasticDto, ShipmentCustomDto>();
        }
    }
}

