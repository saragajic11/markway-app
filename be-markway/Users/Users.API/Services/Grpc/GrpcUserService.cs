// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Grpc.Core;

using Microsoft.AspNetCore.Authorization;

using Markway.Users.API.Constants;
using Markway.Users.API.Models;
using Markway.Users.API.Services.Core;
using UsersService;
using System.ComponentModel.DataAnnotations;

namespace Markway.Users.API.Services.Grpc
{
    public class GrpcUserService : GrpcUser.GrpcUserBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GrpcUserService(IUserService entityService, IMapper mapper)
        {
            _userService = entityService;
            _mapper = mapper;
        }

        [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
        public override async Task<UserReply> GetUserByEmail(
            UserRequest request,
            ServerCallContext context
        )
        {

            User entity = await _userService.GetAsync(request.Id);

            return _mapper.Map<UserReply>(entity);
        }

        public override async Task<CredentialsResponse> GetUserCredentials(
            UserRequest request,
            ServerCallContext context
        )
        {

            _ = new EmailAddressAttribute().IsValid(request.Username);
            User? user = await _userService.GetByUsernameAsync(request.Username);

            return _mapper.Map<CredentialsResponse>(user);
        }

        public override async Task<UserReply> GetUserByUsername(
            UserRequest request,
            ServerCallContext context
        )
        {

            User? user = await _userService.GetByUsernameAsync(request.Username);
            return _mapper.Map<UserReply>(user);
        }

        public override async Task<UserReply> GetUserById(
            UserRequest request,
            ServerCallContext context
        )
        {
            User? user = await _userService.GetAsync(request.Id);

            return _mapper.Map<UserReply>(user);
        }
    }
}
