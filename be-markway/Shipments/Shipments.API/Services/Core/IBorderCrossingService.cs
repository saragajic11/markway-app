// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
namespace Markway.Shipments.API.Services.Core
{
    public interface IBorderCrossingService
    {
        Task<BorderCrossing?> AddAsync(BorderCrossingDto dto);

        Task<IList<BorderCrossing>> GetAllAsync(PageRequest pageRequest);

        Task<BorderCrossing?> GetAsync(long id);
    }
}
