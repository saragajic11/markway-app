// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Pdfs.API.Constants;

namespace Markway.Pdfs.API.Models.DTO
{
    public record ShipmentMailDto
    {
        public long? Id { get; set; }
        public string? Carrier { get; set; }
        public string? LicencePlate { get; set; }
        public string? VehicleType { get; set; }
        public string? Merch { get; set; }
        public string? Amount { get; set; }
        public string? LoadOnLocation { get; set; }
        public string? LoadOffLocation { get; set; }
        public string? LoadOnDate { get; set; }
        public string? LoadOffDate { get; set; }
        public string? ExportCustoms { get; set; }
        public string? ImportCustoms { get; set; }
        public string? Notes { get; set; }
    }
}
