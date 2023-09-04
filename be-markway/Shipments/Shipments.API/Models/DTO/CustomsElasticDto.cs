// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models.DTO
{
    public record CustomsElasticDto: ExampleEntityElasticDto
    {
        public string? Name { get; init; }
        public string? Address { get; init; }

    }
}
