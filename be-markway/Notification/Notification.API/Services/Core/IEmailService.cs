// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Notification.API.Models.DTO;

namespace Markway.Notification.API.Services.Core
{
    public interface IEmailService
    {
        Task SendPdfEmailAsync(PdfEmailDto dto);
    }
}
