// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

namespace Markway.Commons.Authorization
{
    public class PermissionOrScopeRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> Permissions { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Scopes { get; set; } = Enumerable.Empty<string>();

        public PermissionOrScopeRequirement(IEnumerable<string> _permissions, IEnumerable<string> _scopes)
        {
            Permissions = _permissions;
            Scopes = _scopes;
        }
    }
}
