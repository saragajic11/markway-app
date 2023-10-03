// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
namespace Markway.Shipments.API.Services.Core
{
    public interface IShipmentLoadOnLocationService
    {
        Task<ShipmentLoadOnLocation?> AddAsync(ShipmentLoadOnLocationDto dto);

        Task<IList<ShipmentLoadOnLocation>> GetAllAsync(PageRequest pageRequest);

        Task<ShipmentLoadOnLocation?> GetAsync(long id);

        Task<IList<ShipmentLoadOnLocation>> GetAsyncByShipmentId(long shipmentId);

        Task<IList<ShipmentLoadOnLocation>> GetAsyncByShipmentIdAndLoadOnLocationType(long shipmentId, long type);

        Task<IList<ShipmentPopulatedDto>> GetAllShipmentsPopulated(PageRequest pageRequest);

    }
}
