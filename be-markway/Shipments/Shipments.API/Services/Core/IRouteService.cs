// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
namespace Markway.Shipments.API.Services.Core
{
    public interface IRouteService
    {
        Task<ShipmentsRoute?> AddAsync(RouteDto dto);

        Task<IList<ShipmentsRoute>> GetAllAsync(PageRequest pageRequest);

        Task<ShipmentsRoute?> GetAsync(long id);
    }
}
