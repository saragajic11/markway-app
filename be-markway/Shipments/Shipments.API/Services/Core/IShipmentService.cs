// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
namespace Napokon.Shipments.API.Services.Core
{
    public interface IShipmentService
    {
        Task<Shipment?> AddAsync(ShipmentDto dto);

        Task<IList<Shipment>> GetAllAsync(PageRequest pageRequest);

        Task<Shipment?> GetAsync(long id);
    }
}
