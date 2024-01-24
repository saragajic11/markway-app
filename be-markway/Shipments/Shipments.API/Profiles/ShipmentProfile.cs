// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;
using Markway.Shipments.API.Grpc;
using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;

namespace Markway.Shipments.API.Profiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            CreateMap<Shipment, ShipmentDto>();

            CreateMap<ShipmentDto, Shipment>();

            CreateMap<Shipment, ShipmentElasticDto>();

            CreateMap<ShipmentElasticDto, ShipmentDto>();

            CreateMap<Shipment, ShipmentPopulatedDto>();

            CreateMap<ShipmentPopulatedDto, Shipment>();

            // CreateMap<Shipment, ShipmentReply>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //     .ForMember(dest => dest.Carrier, opt => opt.MapFrom(src => src.ShipmentRoutes.FirstOrDefault().Carrier.Name))
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}

public record ShipmentMailDto
    {
        public long? Id { get; set; }
        public string? Carrier { get; set; }
        public string? LicencePlate { get; set; }
        public string? VehicleType { get; set; }
        public string? Merch { get; set; }
        public string? Amount { get; set; }
        public string? LoadOnLocation { get; set; }
        public string? LoadOffLocation { get; set; }
        public string? LoadOnDate { get; set; }
        public string? LoadOffDate { get; set; }
        public string? ExportCustoms { get; set; }
        public string? ImportCustoms { get; set; }
        public string? Notes { get; set; }
    }