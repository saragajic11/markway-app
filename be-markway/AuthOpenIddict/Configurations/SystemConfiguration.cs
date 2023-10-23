// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.AuthOpenIddict.Configurations
{
    public class SystemConfiguration : ISystemConfiguration
    {
        public string DatabaseConnection { get; set; }
        public GrpcConnections GrpcConnections { get; set; } = new GrpcConnections();
    }

    public class GrpcConnections
    {
        public string Users { get; set; }
    }
}
