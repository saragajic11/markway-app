// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Napokon.Shipments.API.Constants;

namespace Napokon.Shipments.API.Models;

public class Customs : Entity
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Address { get; set; }
}