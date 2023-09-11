// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
namespace Napokon.Shipments.API.Services.Core
{
    public interface IShipmentLoadOnLocationService
    {
        Task<ShipmentLoadOnLocation?> AddAsync(ShipmentLoadOnLocationDto dto);

        Task<IList<ShipmentLoadOnLocation>> GetAllAsync(PageRequest pageRequest);

        Task<ShipmentLoadOnLocation?> GetAsync(long id);
    }
}
