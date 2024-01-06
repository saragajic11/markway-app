// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.


using Markway.Notification.API.Grpc;

namespace Markway.Pdfs.API.Services.Grpc.Clients;

public interface INotificationClient
{
    Task<EmailReply> SendPdfEmailAsync(EmailRequest request);
}
