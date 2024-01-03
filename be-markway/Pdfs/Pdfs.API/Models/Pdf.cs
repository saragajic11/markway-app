using System.IO;
// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Markway.Pdfs.API.Models;
public class Pdf : Entity
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Extension { get; set; }
    [Required]
    public string? Path { get; set; }
    [Required]
    public long ReferenceId { get; set; }
}
