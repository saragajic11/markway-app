// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Markway.Shipments.API.Models;
using Markway.Shipments.API.Repository.Core;

namespace Markway.Shipments.API.Repository
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
