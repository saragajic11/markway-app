// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models.DTO
{
    public record RouteDto
    {
        public long? Id { get; set; }

        public long? CarrierId { get; set; }

        public CarrierDto? Carrier { get; set; }

        public long Outcome { get; set; }

        public string? VehicleType { get; set; }

        public string? LicencePlate { get; set; }

        public string? Currency { get; set; }

        public long? ShipmentId { get; set; }

        public IList<ShipmentLoadOnLocationDto>? ShipmentLoadOnLocations { get; set; }

        public IList<ShipmentCustomDto>? ShipmentCustoms { get; set; }

        public BorderCrossingDto? BorderCrossing { get; set; }
    }
}
