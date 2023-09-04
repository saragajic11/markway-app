// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Markway.Shipments.API.Models;
public class Customer : Entity
{
    [Required]
    public string? Name { get; set; }
}
