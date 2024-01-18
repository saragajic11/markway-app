// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Net;
using System.Net.Mail;
using Markway.Commons.Configurations;
using Markway.Notification.API.Errors;
using Markway.Notification.API.Models.DTO;
using Markway.Notification.API.Services.Core;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;

namespace Markway.Notification.API.Services
{
    public class EmailService : IEmailService
    {
        private static ISystemConfiguration _systemConfiguration;
        private readonly SmtpClient _smtpClient;
        private readonly IStringLocalizer _localizer;

        public EmailService(SystemConfiguration systemConfiguration)
        {
            if (systemConfiguration is not null)
            {
                _systemConfiguration = systemConfiguration;
                _smtpClient = new(_systemConfiguration.EmailServer.Host, _systemConfiguration.EmailServer.Port)
                {
                    Credentials = new NetworkCredential(_systemConfiguration.EmailServer.Username, _systemConfiguration.EmailServer.Password),
                    EnableSsl = _systemConfiguration.EmailServer.EnableSsl
                };
                _smtpClient.Credentials = new NetworkCredential(_systemConfiguration.EmailServer.Username, _systemConfiguration.EmailServer.Password);
                _smtpClient.EnableSsl = true;
            }
        }

        public async Task SendPdfEmailAsync(PdfEmailDto dto)
        {
            dto.SendToAddresses = dto.SendToAddresses;
            if (!dto.SendToAddresses.Any())
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest, new ErrorResponse(ErrorCode.SERVICE_ABBREVIATION_0001));
            }

            const string sharedVolumePath = "/app/pdf_input/markway.pdf";

            Attachment attachment = new(sharedVolumePath);

            MailMessage mailMessage = new()
            {
                From = new(_systemConfiguration.EmailServer.User),
                Body = dto.Body,
                Subject = dto.Subject,
                IsBodyHtml = true,
            };

            mailMessage.Attachments.Add(attachment);

            mailMessage.To.Add(string.Join(",", dto.SendToAddresses));

            _ = _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
