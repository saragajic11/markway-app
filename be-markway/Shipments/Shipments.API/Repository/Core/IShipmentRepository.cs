// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;

namespace Markway.Shipments.API.Repository.Core
{
    public interface IShipmentRepository : IBaseRepository<Shipment>
    {
        public Task<Shipment?> GetAsync(long id);

        public Task<IList<Shipment>> GetAllAsync(PageRequest pageRequest);
    }
}

