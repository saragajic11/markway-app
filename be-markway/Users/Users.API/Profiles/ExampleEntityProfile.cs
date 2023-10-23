// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Users.API.Models;
using Markway.Users.API.Models.DTO;

namespace Markway.Users.API.Profiles
{
    public class ExampleEntityProfile : Profile
    {
        public ExampleEntityProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            CreateMap<User, ExampleEntityElasticDto>();

            CreateMap<ExampleEntityElasticDto, UserDto>();
        }
    }
}

