// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Net.Mail;

namespace Markway.Notification.API.Models.DTO
{
    public record PdfEmailDto
    {
        public string SendToAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
