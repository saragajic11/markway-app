﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Grpc.Core;

using Microsoft.AspNetCore.Authorization;

using Markway.Shipments.API.Constants;
using Markway.Shipments.API.Grpc;
using Markway.Shipments.API.Models;
using Markway.Shipments.API.Services.Core;

namespace Markway.Shipments.API.Services.Grpc
{
    public class GrpcShipmentService : GrpcEntity.GrpcEntityBase
    {
        private readonly IShipmentService _entityService;
        private readonly IMapper _mapper;

        public GrpcShipmentService(IShipmentService entityService, IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
        public override async Task<ShipmentReply> GetShipmentById(
            ShipmentRequest request,
            ServerCallContext context
        )
        {
            Shipment entity = await _entityService.GetAsync(request.Id);

            return _mapper.Map<ShipmentReply>(entity);
        }
    }
}