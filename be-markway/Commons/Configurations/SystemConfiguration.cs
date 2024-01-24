// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Commons.Configurations
{
    public class SystemConfiguration : ISystemConfiguration
    {
        public string DatabaseConnection { get; set; }
        public ELKConfiguration ELKConfiguration { get; set; }
        public EmailServer EmailServer { get; set; }
        public S3Settings S3Settings { get; set; } = new S3Settings();
        public Jwt Jwt { get; set; } = new Jwt();
        public string RedisConnectionString { get; set; }
        public string GeneratePdfApi { get; set; }
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

    public class EmailServer
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string AuthMode { get; set; }
        public string User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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

    public class S3Settings
    {
        public string? AccessKey { get; set; }
        public string? AccessSecret { get; set; }
        public string? ServiceURL { get; set; }
        public string? Bucket { get; set; }
        public string? PublicURL { get; set; }
        public string? Region { get; set; }
    }
}

