// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Shipments.API.Models.DTO
{
    public record CustomerDto
    {
        public long? Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Pib { get; set; }

        public string? IdentificationNumber { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? ContactPerson { get; set; }

        public string? AccountNumber { get; set; }

        public string? Iban { get; set; }

        public string? Swift { get; set; }
    }
}
