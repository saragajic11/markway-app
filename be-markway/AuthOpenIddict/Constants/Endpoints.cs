// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.AuthOpenIddict.Constants
{
    public static class Endpoints
    {
        public const string LOGIN = "/authentication/login";
        public const string AUTHORIZE = "/connect/authorize";
        public const string TOKEN = "/connect/token";
        public const string ADMIN_TOKEN = $"/admin{TOKEN}";
        public const string ANONYMOUS_TOKEN = "/connect/token/anonymous";
        public const string USER_INFO = "/connect/userinfo";
    }
}