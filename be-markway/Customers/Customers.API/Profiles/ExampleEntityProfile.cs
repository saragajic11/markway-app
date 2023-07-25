﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Customers.API.Models;
using Napokon.Customers.API.Models.DTO;

namespace Napokon.Customers.API.Profiles
{
    public class ExampleEntityProfile : Profile
    {
        public ExampleEntityProfile()
        {
            CreateMap<Customer, ExampleEntityDto>();

            CreateMap<ExampleEntityDto, Customer>();

            CreateMap<Customer, ExampleEntityElasticDto>();

            CreateMap<ExampleEntityElasticDto, ExampleEntityDto>();
        }
    }
}

