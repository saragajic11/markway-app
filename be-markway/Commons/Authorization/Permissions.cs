// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Commons.Authorization;
public class Permissions
{

    public static class User
    {
        public const string READ = "user:read";
        public const string UPDATE = "user:update";
        public const string DELETE = "user:delete";
        public const string ASSIGN = "user:assign";
        public const string UNASSIGN = "user:unassign";
    }
    
    public static class SubscriptionPackages
    {
        public const string READ = "subscription_package:read";
        public const string UPDATE = "subscription_package:update";
        public const string DELETE = "subscription_package:delete";
    }
    
    public static class Image
    {
        public const string POST = "image:post";
    }

    public static class COUNTRY
    {
        public const string CREATE = "country:create";
        public const string DELETE = "country:delete";
    }

    public static class Ad
    {
        public const string CREATE = "ad:create";
    }

    public static class Synonym
    {
        public const string READ = "synonym:read";
        public const string CREATE = "synonym:create";
        public const string DELETE = "synonym:delete";
    }

    public static class AdDataStructure
    {
        public const string READ = "ad_data_structure:read";
        public const string CREATE = "ad_data_structure:create";
    }

    public static class ThirdPartyIntegration
    {
        public const string READ = "default_field_value:read";
    }
}
