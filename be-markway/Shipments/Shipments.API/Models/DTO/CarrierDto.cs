// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Napokon.Shipments.API.Models.DTO
{

    public record CarrierDto
    {
        public long? Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
