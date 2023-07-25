// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Customer.API.Models;
using Napokon.Customer.API.Models.DTO;

namespace Napokon.Customer.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();

            CreateMap<CustomerDto, CustomerEntity>();

            CreateMap<CustomerEntity, CustomerElasticDto>();

            CreateMap<CustomerElasticDto, CustomerDto>();
        }
    }
}

