﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Grpc.Core;

using Microsoft.AspNetCore.Authorization;

using Markway.Pdfs.API.Constants;
using Markway.Pdfs.API.Grpc;
using Markway.Pdfs.API.Models;
using Markway.Pdfs.API.Services.Core;

namespace Markway.Pdfs.API.Services.Grpc
{
    public class GrpcEntityService : GrpcEntity.GrpcEntityBase
    {
        private readonly IPdfService _entityService;
        private readonly IMapper _mapper;

        public GrpcEntityService(IPdfService entityService, IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
        public override async Task<EntityReply> GetEntityById(
            EntityRequest request,
            ServerCallContext context
        )
        {
            Pdf entity = await _entityService.GetAsync(request.Id);

            return _mapper.Map<EntityReply>(entity);
        }
    }
}
