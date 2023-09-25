// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;

namespace Markway.Shipments.API.Repository.Core
{
    public interface IShipmentLoadOnLocationRepository : IBaseRepository<ShipmentLoadOnLocation>
    {
        public Task<ShipmentLoadOnLocation?> GetAsync(long id);

        public Task<IList<ShipmentLoadOnLocation>?> GetAsyncByShipmentId(long shipmentId);

        public Task<IList<ShipmentLoadOnLocation>?> GetAsyncByShipmentIdAndLoadOnLocationType(long shipmentId, long type);

    }
}

