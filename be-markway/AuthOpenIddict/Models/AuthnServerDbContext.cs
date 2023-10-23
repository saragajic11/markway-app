// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace Markway.AuthOpenIddict.Models
{
    public class AuthnServerDbContext : DbContext
    {
        public AuthnServerDbContext(DbContextOptions<AuthnServerDbContext> options) : base(options) { }
    }
}