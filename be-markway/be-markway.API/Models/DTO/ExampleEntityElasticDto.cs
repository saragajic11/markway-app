// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Napokon.be_markway.API.Models.DTO
{
    public record ExampleEntityElasticDto
    {
        public long? Id { get; init; }

        public string? Property { get; init; }

        public DateTime DateCreated { get; init; }

        public DateTime DateUpdated { get; init; }
    }
}
