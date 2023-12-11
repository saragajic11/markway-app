// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models.DTO
{

    public record ShipmentCustomDto
    {
        public long? Id { get; set; }

        public CustomsType type { get; set; }

        public long? RouteId { get; set; }

        public long? CustomId { get; set; }

        public CustomsDto? Custom { get; set; }
    }
}
