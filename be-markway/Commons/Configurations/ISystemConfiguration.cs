// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
namespace Markway.Commons.Configurations
{
    public interface ISystemConfiguration
    {
        string DatabaseConnection { get; }

        ELKConfiguration ELKConfiguration { get; }

        Jwt Jwt { get; }

        string RedisConnectionString { get; }

        GrpcConnections GrpcConnections { get; set; }

        public S3Settings S3Settings { get; set; }
        public EmailServer EmailServer { get; set; }
    }
}