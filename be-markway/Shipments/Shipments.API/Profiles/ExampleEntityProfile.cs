// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;

namespace Napokon.Shipments.API.Profiles
{
    public class ExampleEntityProfile : Profile
    {
        public ExampleEntityProfile()
        {
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, ExampleEntityElasticDto>();

            CreateMap<ExampleEntityElasticDto, CustomerDto>();
        }
    }
}

