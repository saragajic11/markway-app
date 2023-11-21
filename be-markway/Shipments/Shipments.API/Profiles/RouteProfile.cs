// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;

namespace Markway.Shipments.API.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<ShipmentsRoute, RouteDto>();

            CreateMap<RouteDto, ShipmentsRoute>();

            CreateMap<ShipmentsRoute, ShipmentsRouteElasticDto>();

            CreateMap<ShipmentsRouteElasticDto, RouteDto>();
        }
    }
}

