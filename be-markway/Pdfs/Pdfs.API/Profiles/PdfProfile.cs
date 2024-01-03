// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Pdfs.API.Models;
using Markway.Pdfs.API.Models.DTO;

namespace Markway.Pdfs.API.Profiles
{
    public class PdfProfile : Profile
    {
        public PdfProfile()
        {
            CreateMap<Pdf, PdfDto>();

            CreateMap<PdfDto, Pdf>();

            CreateMap<Pdf, ExampleEntityElasticDto>();

            CreateMap<ExampleEntityElasticDto, PdfDto>();
        }
    }
}
