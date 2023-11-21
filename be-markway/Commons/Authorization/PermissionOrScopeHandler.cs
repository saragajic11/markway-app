// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;

namespace Markway.Commons.Authorization
{
    public class PermissionOrScopeHandler : AuthorizationHandler<PermissionOrScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionOrScopeRequirement requirement)
        {
            if (requirement.Permissions is not null && context.User.HasClaim(claim => claim.Type == Claims.CLAIM_PERMISSIONS && requirement.Permissions.Contains(claim.Value)))
            {
                context.Succeed(requirement);
            }

            if(requirement.Scopes is not null && context.User.HasClaim(c => "scope".Equals(c.Type) && requirement.Scopes.Contains(c.Value)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
