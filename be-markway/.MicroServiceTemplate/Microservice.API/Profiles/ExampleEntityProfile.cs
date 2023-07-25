// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Microservice.API.Models;
using Napokon.Microservice.API.Models.DTO;

namespace Napokon.Microservice.API.Profiles
{
    public class ExampleEntityProfile : Profile
    {
        public ExampleEntityProfile()
        {
            CreateMap<ExampleEntity, ExampleEntityDto>();

            CreateMap<ExampleEntityDto, ExampleEntity>();

            CreateMap<ExampleEntity, ExampleEntityElasticDto>();

            CreateMap<ExampleEntityElasticDto, ExampleEntityDto>();
        }
    }
}

