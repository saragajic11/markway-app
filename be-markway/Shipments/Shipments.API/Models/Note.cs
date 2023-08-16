// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Napokon.Shipments.API.Constants;

namespace Napokon.Shipments.API.Models;

public class Note : Entity
{
    [Required]
    public string? Description { get; set; }
}
