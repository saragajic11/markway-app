// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;

namespace Markway.Shipments.API.Profiles
{
    public class ShipmentLoadOnLocationProfile : Profile
    {
        public ShipmentLoadOnLocationProfile()
        {
            CreateMap<ShipmentLoadOnLocation, ShipmentLoadOnLocationDto>();

            CreateMap<ShipmentLoadOnLocationDto, ShipmentLoadOnLocation>();

            CreateMap<ShipmentLoadOnLocation, ShipmentLoadOnLocationElasticDto>();

            CreateMap<ShipmentLoadOnLocationElasticDto, ShipmentLoadOnLocationDto>();

            CreateMap<ShipmentLoadOnLocation, ShipmentLoadOnLocationSpecificDto>();

            CreateMap<ShipmentLoadOnLocationSpecificDto, ShipmentLoadOnLocation>();
        }
    }
}

