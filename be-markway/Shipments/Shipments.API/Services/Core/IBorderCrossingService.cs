// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
namespace Napokon.Shipments.API.Services.Core
{
    public interface IBorderCrossingService
    {
        Task<BorderCrossing?> AddAsync(BorderCrossingDto dto);

        Task<IList<BorderCrossing>> GetAllAsync(PageRequest pageRequest);

        Task<BorderCrossing?> GetAsync(long id);
    }
}
