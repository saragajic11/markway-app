// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Napokon.Customer.API.Models;
public class ExampleEntity : Entity
{

    [Required]
    public string? Name { get; set; }
}
