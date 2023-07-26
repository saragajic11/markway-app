// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Napokon.Customers.API.Models.DTO
{
    public record CustomerElasticDto
    {
        public long? Id { get; init; }

        public string? Name { get; init; }

        public DateTime DateCreated { get; init; }

        public DateTime DateUpdated { get; init; }
    }
}
