// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Napokon.Commons.Configurations
{
    public class SystemConfiguration : ISystemConfiguration
    {
        public string DatabaseConnection { get; set; }
        public ELKConfiguration ELKConfiguration { get; set; }

        public Jwt Jwt { get; set; } = new Jwt();

        public string RedisConnectionString { get; set; }
        public GrpcConnections GrpcConnections { get; set; } = new GrpcConnections();
    }

    public class Jwt
    {
        public string Authority { get; set; }

        public TokenValidation TokenValidation { get; set; } = new TokenValidation();
    }

    public class TokenValidation
    {
        public string Key { get; set; }
    }

    public class ELKConfiguration
    {
        public string Uri { get; set; }
        public string DefaultIndex { get; set; }
        public string[] Indices { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class GrpcConnections
    {
        public string? Platform { get; set; }
        public string? Notification { get; set; }
        public string? User { get; set; }
        public string? Ad { get; set; }
        public string? Image { get; set; }
    }
}

