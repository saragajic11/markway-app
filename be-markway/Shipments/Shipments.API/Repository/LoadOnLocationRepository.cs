// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Repository.Core;

namespace Napokon.Shipments.API.Repository
{
    public class LoadOnLocationRepository : BaseRepository<LoadOnLocation>, ILoadOnLocationRepository
    {
        public LoadOnLocationRepository(ShipmentsContext context)
            : base(context) { }
    }
}
