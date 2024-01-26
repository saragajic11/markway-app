// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
namespace Markway.Shipments.API.Services.Core
{
    public interface IShipmentService
    {
        Task<Shipment?> AddAsync(ShipmentDto dto);

        Task<IList<Shipment>> GetAllAsync(ShipmentFilter filter);

        Task<Shipment?> GetAsync(long id);

        Task<bool> DeleteAsync(long id);

        Task<Shipment?> UpdateStatusAsync(long id, long statusId);
    }
}
