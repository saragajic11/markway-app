// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models;
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

    [Required]
    public long? CarrierId { get; set; }

    [ForeignKey("CarrierId")]
    public Carrier? Carrier { get; set; }

    [Required]
    public long? CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }

    [Required]
    public long? NoteId { get; set; }

    [ForeignKey("NoteId")]
    public Note? Note { get; set; }

    [Required]
    public long? BorderCrossingId { get; set; }

    [ForeignKey("BorderCrossingId")]
    public BorderCrossing? BorderCrossing { get; set; }
}
