// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Markway.AuthOpenIddict.Views.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public string? GrantType { get; set; }

        public LoginDto() { }
    }
}

