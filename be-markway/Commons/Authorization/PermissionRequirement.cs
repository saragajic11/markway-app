// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

namespace Markway.Commons.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> Permissions { get; set; } = Enumerable.Empty<string>();

        public PermissionRequirement(IEnumerable<string> _permissions)
        {
            Permissions = _permissions;
        }
    }
}

