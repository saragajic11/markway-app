// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Markway.Shipments.API.Models;
using Markway.Shipments.API.Repository.Core;

namespace Markway.Shipments.API.Repository
{
    public class ShipmentCustomRepository : BaseRepository<ShipmentCustoms>, IShipmentCustomRepository
    {
        public ShipmentCustomRepository(ShipmentsContext context)
            : base(context) { 
                
            }

        public override async Task<ShipmentCustoms?> GetAsync(long id)
        {
            return await ShipmentsContext.ShipmentCustoms
            .Include(x => x.Shipment)
            .Include(x => x.Custom)
            .Where(shipmentCustom => shipmentCustom.Id == id && !shipmentCustom.Deleted)
            .FirstOrDefaultAsync();
        }
    }
}
