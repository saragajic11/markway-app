// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Markway.Shipments.API.Repository
{
    public class RouteRepository : BaseRepository<ShipmentsRoute>, IRouteRepository
    {
        public RouteRepository(ShipmentsContext context)
            : base(context) { }

        public override async Task<ShipmentsRoute?> GetAsync(long id)
        {
            return await ShipmentsContext.ShipmentsRoutes
            .Include(x => x.Carrier)
            .Include(x => x.Shipment)
            .Include(x => x.Note)
            .Where(route => route.Id == id && !route.Deleted)
            .FirstOrDefaultAsync();
        }

        public override async Task<IList<ShipmentsRoute>> GetAllAsync(PageRequest pageRequest)
        {
            return await ShipmentsContext.ShipmentsRoutes
            .Include(x => x.Carrier)
            .Include(x => x.Shipment)
            .Include(x => x.Note)
            .Where(route => !route.Deleted)
            .ToListAsync();
        }
    }
}
