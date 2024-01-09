// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;
using Markway.Notification.API.Grpc;
using Markway.Notification.API.Models;
using Markway.Notification.API.Models.DTO;

namespace Markway.Notification.API.Profiles
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<EmailRequest, PdfEmailDto>()
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.SendToAddresses, opt => opt.MapFrom(src => src.SendToAddress));
        }
    }
}
