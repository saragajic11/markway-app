// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Constants;

namespace Napokon.Shipments.API.Models.DTO
{

    public record ShipmentLoadOnLocationDto
    {
        public long? Id { get; set; }

        public DateTime date { get; set; }

        public CustomsType type { get; set; }

        public long? ShipmentId { get; set; }

        public ShipmentDto? Shipment { get; set; }

        public long? LoadOnLocationId { get; set; }

        public LoadOnLocationDto? LoadOnLocation { get; set; }
    }
}
