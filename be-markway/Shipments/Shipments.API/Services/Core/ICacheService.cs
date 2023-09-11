// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Shipments.API.Services.Core
{
    public interface ICacheService<TCacheEntity> where TCacheEntity : class
    {
        Task<bool> HasKeysAsync();

        Task<IList<TCacheEntity>> GetAllAsync();

        Task<TCacheEntity?> GetByKeyAsync(string key);

        Task<string> InsertAsync(TCacheEntity cachedEntity);

        Task<List<string>> InsertBulkAsync(IList<TCacheEntity> cachedEntities);

        Task DeleteAsync(string key);

    }
}
