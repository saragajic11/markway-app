// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.AuthOpenIddict.Configurations
{
    public interface ISystemConfiguration
    {
        string DatabaseConnection { get; }

        GrpcConnections GrpcConnections { get; }
    }
}

