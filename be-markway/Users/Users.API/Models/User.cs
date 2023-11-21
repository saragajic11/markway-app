// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Markway.Commons.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Markway.Users.API.Models;
public class User : Entity
{
    public string? Name { get; set; }

    [ProtectedPersonalData]
    [PersonalData]
    public string? Email { get; set; }

    public string? Password { get; set; }

    [Required]
    public List<Role>? Roles { get; set; }

    public UserStatus Status { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty;
}
