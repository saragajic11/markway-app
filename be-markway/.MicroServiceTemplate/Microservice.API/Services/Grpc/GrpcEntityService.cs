﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Grpc.Core;

using Microsoft.AspNetCore.Authorization;

using Markway.Microservice.API.Constants;
using Markway.Microservice.API.Grpc;
using Markway.Microservice.API.Models;
using Markway.Microservice.API.Services.Core;

namespace Markway.Microservice.API.Services.Grpc
{
    public class GrpcEntityService : GrpcEntity.GrpcEntityBase
    {
        private readonly IExampleEntityService _entityService;
        private readonly IMapper _mapper;

        public GrpcEntityService(IExampleEntityService entityService, IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
        public override async Task<EntityReply> GetEntityById(
            EntityRequest request,
            ServerCallContext context
        )
        {
            ExampleEntity entity = await _entityService.GetAsync(request.Id);

            return _mapper.Map<EntityReply>(entity);
        }
    }
}
