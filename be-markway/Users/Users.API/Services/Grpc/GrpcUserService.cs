// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Grpc.Core;

using Microsoft.AspNetCore.Authorization;

using Markway.Users.API.Constants;
using Markway.Users.API.Models;
using Markway.Users.API.Services.Core;
using UsersService;

namespace Markway.Users.API.Services.Grpc
{
    public class GrpcUserService : GrpcUser.GrpcUserBase
    {
        private readonly IUserService _entityService;
        private readonly IMapper _mapper;

        public GrpcUserService(IUserService entityService, IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
        public override async Task<UserReply> GetUserByEmail(
            UserRequest request,
            ServerCallContext context
        )
        {
            User entity = await _entityService.GetAsync(request.Id);

            return _mapper.Map<UserReply>(entity);
        }
    }
}
