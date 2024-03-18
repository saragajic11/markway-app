// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models.DTO
{
    public record ShipmentDto
    {
        public long? Id { get; set; }

        public long? ExternalId { get; set; }

        public string? Description { get; set; }

        // public string? Merch { get; set; }

        // public long? MerchAmount { get; set; }

        public long? Income { get; set; }

        public string? IncomeCurrency { get; set; }

        public long? Profit { get; set; }

        public Status? Status { get; set; }

        public long? CustomerId { get; set; }

        public CustomerDto? Customer { get; set; }

        public IList<RouteDto>? ShipmentRoutes { get; set; }

    }
}
