// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Net;

using Grpc.Core;
using Markway.Notification.API.Grpc;
using Markway.Pdfs.API.Errors;
using Microsoft.Net.Http.Headers;
using static Markway.Notification.API.Grpc.GrpcEmail;

namespace Markway.Pdfs.API.Services.Grpc.Clients;

public class NotificationClient : INotificationClient
{
    private readonly ILogger _logger;
    private readonly GrpcEmailClient _grpcEmailClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public NotificationClient(ILogger<NotificationClient> logger, GrpcEmailClient grpcEmailClient)
    {
        _logger = logger;
        _grpcEmailClient = grpcEmailClient;
    }

    public async Task<EmailReply> SendPdfEmailAsync(EmailRequest request)
    {
        try
        {
            return await _grpcEmailClient.SendEmailAsync(request);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error in NotificationClient in SendPdfEmailAsync {e.Message} in {e.StackTrace}");
            throw new HttpResponseException(HttpStatusCode.BadRequest, new ErrorResponse(ErrorCode.SERVICE_ABBREVIATION_0001));
        }
    }
}
