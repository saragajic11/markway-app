// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Grpc.Core;

using Microsoft.AspNetCore.Authorization;

using Markway.Notification.API.Constants;
using Markway.Notification.API.Grpc;
using Markway.Notification.API.Services.Core;
using Markway.Notification.API.Models.DTO;

namespace Markway.Notification.API.Services.Grpc
{
    public class GrpcEmailService : GrpcEmail.GrpcEmailBase
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public GrpcEmailService(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        // [Authorize(Policy = Policies.Authorization.ACTION_ENTITY_NAME)]
        public override async Task<EmailReply> SendEmail(
            EmailRequest request,
            ServerCallContext context
        )
        {
            await _emailService.SendPdfEmailAsync(_mapper.Map<PdfEmailDto>(request));

            return new()
            {
                IsSent = true
            };
        }
    }
}
