// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Markway.Shipments.API.Models;
public class ShipmentsRoute : Entity
{
    [Required]
    public long? CarrierId { get; set; }

    [ForeignKey("CarrierId")]
    public Carrier? Carrier { get; set; }

    [Required]
    public long? Outcome { get; set; }

    [Required]
    public string? OutcomeCurrency { get; set; }

    [Required]
    public string? VehicleType { get; set; }

    [Required]
    public string? LicencePlate { get; set; }

    [Required]
    public long? DateOfPayment { get; set; }

    public long? ShipmentId { get; set; }

    [ForeignKey("ShipmentId")]
    public Shipment? Shipment { get; set; }

    [InverseProperty("Route")]
    public ICollection<ShipmentLoadOnLocation>? ShipmentLoadOnLocations { get; set; }

    [InverseProperty("Route")]
    public ICollection<ShipmentCustoms>? ShipmentCustoms { get; set; }

    [ForeignKey("BorderCrossingId")]
    public BorderCrossing? BorderCrossing { get; set; }

    [Required]
    public long? NoteId { get; set; }

    [ForeignKey("NoteId")]
    public Note? Note { get; set; }
}
