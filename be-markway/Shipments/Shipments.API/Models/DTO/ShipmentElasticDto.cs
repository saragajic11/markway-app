// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Constants;

namespace Napokon.Shipments.API.Models.DTO
{
    public record ShipmentElasticDto : ExampleEntityElasticDto
    {
        public string? Description { get; init; }

        public Status? Status { get; init; }

        public string? Merch { get; init; }

        public long? MerchAmount { get; init; }

        public string? VehicleType { get; init; }

        public string? LicencePlate { get; init; }

        public long? Income { get; init; }

        public long? Outcome { get; init; }

        public long? Profit { get; init; }

        //TODO: add foreign key for customer_id, border_crossing_id, carrier_id, note_id, customs_id
    }
}
