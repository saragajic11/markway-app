// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;

namespace Markway.Shipments.API.Profiles
{
    public class BorderCrossingProfile : Profile
    {
        public BorderCrossingProfile()
        {
            CreateMap<BorderCrossing, BorderCrossingDto>();

            CreateMap<BorderCrossingDto, BorderCrossing>();

            CreateMap<BorderCrossing, BorderCrossingElasticDto>();

            CreateMap<BorderCrossingElasticDto, BorderCrossingDto>();
        }
    }
}

