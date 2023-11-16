// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Auth.Configurations
{
    public class AuthenticationConfiguration : IAuhtenticationConfiguration
    {
        public const string ALLOW_ALL_ORIGIN = "ALLOW_ALL_ORIGIN";

        public string? Scheme { get; set; }

        public Jwt Jwt { get; set; } = new Jwt();
    }

    public class Jwt
    {
        public string? Authority { get; set; }

        public TokenValidation TokenValidation { get; set; } =
            new TokenValidation();
    }

    public class TokenValidation
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Subject { get; set; }
    }
}
