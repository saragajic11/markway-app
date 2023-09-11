// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Constants;

namespace Napokon.Shipments.API.Models.DTO
{
    public record ShipmentDto
    {
        public long? Id { get; set; }

        public string? Description { get; set; }

        public Status? Status { get; set; }

        public string? Merch { get; set; }

        public long? MerchAmount { get; set; }

        public string? VehicleType { get; set; }

        public string? LicencePlate { get; set; }

        public long? Income { get; set; }

        public long? Outcome { get; set; }

        public long? Profit { get; set; }

        //TODO: add foreign key for customer_id, border_crossing_id, carrier_id, note_id, customs_id

    }
}
