// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Pdfs.API.Models.DTO
{

    public record PdfDto
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public string? Path { get; set; }
        public long ReferenceId { get; set; }
    }
}
