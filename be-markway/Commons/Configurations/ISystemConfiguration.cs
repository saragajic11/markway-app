// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
namespace Napokon.Commons.Configurations
{
    public interface ISystemConfiguration
    {
        string DatabaseConnection { get; }

        ELKConfiguration ELKConfiguration { get; }

        Jwt Jwt { get; }
        
        string RedisConnectionString { get; }

        GrpcConnections GrpcConnections { get; set; }
    }
}