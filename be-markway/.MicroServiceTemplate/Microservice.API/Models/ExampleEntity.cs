// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Napokon.Microservice.API.Models;
public class ExampleEntity : Entity
{

    [Required]
    public string? Property { get; set; }
}
