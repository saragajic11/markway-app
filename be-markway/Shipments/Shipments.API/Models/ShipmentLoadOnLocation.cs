// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Markway.Shipments.API.Constants;

namespace Markway.Shipments.API.Models;

public class ShipmentLoadOnLocation : Entity
{
    [Required]
    public DateTime date { get; set; }

    [Required]
    public CustomsType type { get; set; }

    [Required]
    public long? RouteId { get; set; }

    [ForeignKey("RouteId")]
    public ShipmentsRoute? Route { get; set; }

    [Required]
    public long? LoadOnLocationId { get; set; }

    [ForeignKey("LoadOnLocationId")]
    public LoadOnLocation? LoadOnLocation { get; set; }
}
