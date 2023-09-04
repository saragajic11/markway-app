// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Microservice.API.Models;
using Markway.Microservice.API.Models.DTO;

namespace Markway.Microservice.API.Profiles
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

