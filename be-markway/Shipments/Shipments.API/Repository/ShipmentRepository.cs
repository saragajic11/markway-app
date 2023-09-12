// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
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
            .Include(x => x.Carrier)
            .Include(x => x.Customer)
            .Include(x => x.BorderCrossing)
            .Include(x => x.Note)
            .Where(shipment => shipment.Id == id && !shipment.Deleted)
            .FirstOrDefaultAsync();
        }
    }
}
