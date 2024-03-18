// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Markway.Shipments.API.Repository
{
    public class ShipmentRepository : BaseRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(ShipmentsContext context)
            : base(context) { }

        public override async Task<Shipment?> GetAsync(long id)
        {
            return await ShipmentsContext.Shipments
                .Include(x => x.Customer)
                .Where(shipment => shipment.Id == id && !shipment.Deleted)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Shipment>> GetAllAsync(ShipmentFilter filter)
        {
            IQueryable<Shipment> query = ShipmentsContext.Shipments.AsQueryable();

            if (filter.UserId.HasValue && filter.UserId != 0)
            {
                query = query.Where(shipment => filter.UserId.Equals(shipment.UserId));
            }

            return await query
                .Include(x => x.Customer)
                .Include(x => x.ShipmentRoutes)
                    .ThenInclude(route => route.Carrier)
                .Include(x => x.ShipmentRoutes)
                    .ThenInclude(route => route.ShipmentCustoms)
                        .ThenInclude(shipmentCustom => shipmentCustom.Custom)
                .Include(x => x.ShipmentRoutes)
                    .ThenInclude(route => route.ShipmentLoadOnLocations)
                        .ThenInclude(shipmentLoadOnLocation => shipmentLoadOnLocation.LoadOnLocation)
                .Include(x => x.ShipmentRoutes)
                    .ThenInclude(route => route.BorderCrossing)
                .Where(shipment => !shipment.Deleted)
                .ToListAsync();
        }
    }
}
