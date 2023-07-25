// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customer.API.Services.Core;

using Redis.OM;
using Redis.OM.Searching;

namespace Napokon.Platform.API.Services.Core
{

    public class CacheService<TCacheEntity> : ICacheService<TCacheEntity> where TCacheEntity : class
    {
        readonly TimeSpan CACHE_KEY_DURATION = TimeSpan.FromMinutes(5);

        private readonly RedisConnectionProvider _provider;
        private readonly RedisCollection<TCacheEntity> _cacheEntities;

        public CacheService(RedisConnectionProvider provider)
        {
            _provider = provider;
            _cacheEntities = (RedisCollection<TCacheEntity>)_provider.RedisCollection<TCacheEntity>();
        }

        public async Task<bool> HasKeysAsync()
        {
            return await _cacheEntities.AnyAsync();
        }

        public async Task<IList<TCacheEntity>?> GetAllAsync()
        {
            return await _cacheEntities.ToListAsync();
        }

        public async Task<TCacheEntity?> GetByKeyAsync(string key)
        {
            return await _cacheEntities.FindByIdAsync($"{typeof(TCacheEntity).Name}:{key}");
        }

        public Task<string> InsertAsync(TCacheEntity cacheEntity)
        {
            return _cacheEntities.InsertAsync(cacheEntity, CACHE_KEY_DURATION);
        }

        public async Task<List<string>> InsertBulkAsync(IList<TCacheEntity> cachedEntities)
        {
            return await _cacheEntities.Insert(cachedEntities, CACHE_KEY_DURATION);
        }

        public async Task DeleteAsync(string key)
        {
            TCacheEntity? cachedEntity = await GetByKeyAsync($"{typeof(TCacheEntity).Name}:{key}");
            
            if (cachedEntity != null) {
                await _cacheEntities.DeleteAsync(cachedEntity);
            }
        }
    }
}
