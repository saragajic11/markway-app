// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models.DTO
{

    public record ShipmentPopulatedDto
    {
        public long Id { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public string? Merch { get; set; }

        public long? MerchAmount { get; set; }

        public string? VehicleType { get; set; }

        public string? LicencePlate { get; set; }

        public long? Income { get; set; }

        public long? Outcome { get; set; }

        public long? Profit { get; set; }

        public long? CarrierId { get; set; }

        public CarrierDto? Carrier { get; set; }

        public long? CustomerId { get; set; }

        public CustomerDto? Customer { get; set; }

        public long? BorderCrossingId { get; set; }

        public BorderCrossingDto? BorderCrossing { get; set; }

        public long? NoteId { get; set; }

        public NoteDto? Note { get; set; }

        public IList<ShipmentLoadOnLocationSpecificDto>? ShipmentLoadOnLocations { get; set; }
    }
}
