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
    public string? Merch { get; set; }

    [Required]
    public long? MerchAmount { get; set; }

    [Required]
    public long? Income { get; set; }

    [Required]
    public long? Profit { get; set; }

    [Required]
    public long? CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }

    [Required]
    public long? NoteId { get; set; }

    [ForeignKey("NoteId")]
    public Note? Note { get; set; }

    [InverseProperty("Shipment")]
    public ICollection<ShipmentsRoute>? ShipmentRoutes { get; set; }

    public long? UserId { get; set; }
}
