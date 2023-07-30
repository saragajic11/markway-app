// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.be_markway.API.Models;
using Napokon.be_markway.API.Models.DTO;

namespace Napokon.be_markway.API.Profiles
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

