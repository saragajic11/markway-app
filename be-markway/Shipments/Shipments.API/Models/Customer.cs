// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Markway.Shipments.API.Models;
public class Customer : Entity
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public string? Pib { get; set; }

    [Required]
    public string? IdentificationNumber { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required]
    public string? ContactPerson { get; set; }

    [Required]
    public string? AccountNumber { get; set; }

    [Required]
    public string? Iban { get; set; }

    [Required]
    public string? Swift { get; set; }
}
