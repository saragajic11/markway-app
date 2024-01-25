// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Markway.Shipments.API.Repository
{
    public class CarrierRepository : BaseRepository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(ShipmentsContext context)
            : base(context) { }

        public async Task<IList<Carrier>> GetAllAsync()
        {
            return await ShipmentsContext.Carriers
            .Where(carrier => !carrier.Deleted)
            .ToListAsync();
        }
    }
}
