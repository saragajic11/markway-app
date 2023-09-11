// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Repository.Core;

namespace Napokon.Shipments.API.Repository
{
    public class ShipmentLoadOnLocationRepository : BaseRepository<ShipmentLoadOnLocation>, IShipmentLoadOnLocationRepository
    {
        public ShipmentLoadOnLocationRepository(ShipmentsContext context)
            : base(context) { 
                
            }

        public override async Task<ShipmentLoadOnLocation?> GetAsync(long id)
        {
            return await ShipmentsContext.ShipmentLoadOnLocations
            .Include(x => x.Shipment)
            .Include(x => x.LoadOnLocation)
            .Where(shipmentLoadOnLocation => shipmentLoadOnLocation.Id == id && !shipmentLoadOnLocation.Deleted)
            .FirstOrDefaultAsync();
        }
    }
}
