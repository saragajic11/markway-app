// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Commons.Authorization
{
    public class Roles
    {
        public static readonly string SUPER_ADMIN = "SUPER_ADMIN";
        public static readonly string EMPLOYEE = "EMPLOYEE";
        public static readonly Dictionary<string, List<string>> RolePermissions = new()
        {
            {Roles.SUPER_ADMIN, new List<string> { Permissions.S3Files.CREATE, Permissions.Shipment.CREATE}},
            {Roles.EMPLOYEE, new List<string> { Permissions.S3Files.CREATE, Permissions.Shipment.CREATE}}
        };
    }
}
