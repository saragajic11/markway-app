// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Shipments.API.Models.DTO
{
    public record CustomerDto
    {
        public long? Id { get; set; }

        public string? Name { get; set; }
    }
}
