// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Napokon.Shipments.API.Models.DTO
{

    public record NoteDto
    {
        public long? Id { get; set; }

        public string? Description { get; set; }
    }
}
