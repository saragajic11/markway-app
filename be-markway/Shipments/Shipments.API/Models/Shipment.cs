// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Napokon.Shipments.API.Constants;

namespace Napokon.Shipments.API.Models;
public class Shipment : Entity
{
    [Required]
    public string? Description { get; set; }

    [Required]
    public Status? Status { get; set; }

    [Required]
    public string? Merch { get; set; }

    [Required]
    public long? MerchAmount { get; set; }

    [Required]
    public string? VehicleType { get; set; }

    [Required]
    public string? LicencePlate { get; set; }

    [Required]
    public long? Income { get; set; }

    [Required]
    public long? Outcome { get; set; }

    [Required]
    public long? Profit { get; set; }

    //TODO: add foreign key for customer_id, border_crossing_id, carrier_id, note_id, customs_id
}
