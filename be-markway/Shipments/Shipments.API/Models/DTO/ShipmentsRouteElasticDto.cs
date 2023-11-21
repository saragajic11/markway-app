// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models.DTO
{
    public record ShipmentsRouteElasticDto : ExampleEntityElasticDto
    {
        public long? CarrierId { get; set; }
        public Carrier? Carrier { get; set; }
        public long Outcome { get; set; }
        public string? VehicleType { get; set; }
        public string? LicencePlate { get; set; }

        public string? Currency { get; set; }
        public Status? Status { get; set; }
        public long? ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
    }
}
