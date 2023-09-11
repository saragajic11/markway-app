// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Commons.Authorization
{
    public class Roles
    {
        public static readonly string SUPER_ADMIN = "SUPER_ADMIN";
        public static readonly string BUYER = "BUYER";
        public static readonly string SELLER = "SELLER";
        public static readonly string ANONYMOUS = "ANONYMOUS";

        public static readonly Dictionary<string, List<string>> RolePermissions = new()
        {
            {Roles.SUPER_ADMIN, new List<string> { Permissions.User.READ, Permissions.User.UPDATE, Permissions.User.ASSIGN, Permissions.User.UNASSIGN,
                Permissions.User.DELETE, Permissions.SubscriptionPackages.READ, Permissions.SubscriptionPackages.UPDATE, Permissions.SubscriptionPackages.DELETE,
                Permissions.AdDataStructure.CREATE, Permissions.AdDataStructure.READ } },
            {Roles.BUYER, new List<string> { Permissions.User.READ, Permissions.User.UPDATE,Permissions.SubscriptionPackages.READ,
                Permissions.Image.POST, Permissions.COUNTRY.CREATE, Permissions.COUNTRY.DELETE, Permissions.Ad.CREATE,
                Permissions.Synonym.READ, Permissions.Synonym.CREATE, Permissions.Synonym.DELETE } },
            {Roles.SELLER, new List<string> { Permissions.User.READ, Permissions.User.UPDATE, Permissions.SubscriptionPackages.READ } },
            {Roles.ANONYMOUS, new List<string>{Permissions.User.READ} }
        };
    }
}
