// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;
using Markway.Commons.Authorization;
using Markway.Users.API.Models;
using Markway.Users.API.Models.DTO;
using UsersService;
using static BCrypt.Net.BCrypt;

namespace Markway.Users.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => HashPassword(src.Password)))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => new List<Role> { Role.EMPLOYEE }))
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.DateUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.Deleted, opt => opt.Ignore());

            CreateMap<User, CredentialsResponse>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<User, UserReply>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
