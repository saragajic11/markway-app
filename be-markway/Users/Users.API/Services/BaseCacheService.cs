// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
using Markway.Users.API.Models.DTO;
using Markway.Users.API.Repository.Core;
using Markway.Users.API.Services.Core;

namespace Markway.Users.API.Services
{
    public class BaseCacheService<TEntity> : BaseService<TEntity>
        where TEntity : class 
    {
        protected readonly ICacheService<TEntity> _cacheService;

        public BaseCacheService() {}

        public BaseCacheService(
            ILogger<BaseCacheService<TEntity>> logger, 
            IUnitOfWork unitOfWork, 
            IElasticSearchService elasticSearchService,
            ICacheService<TEntity> cacheService) : base(logger, unitOfWork, elasticSearchService)
        {
            _cacheService = cacheService;
        }

        public override async Task<IList<TEntity>> AddBulkAsync(IList<TEntity> entities)
        {
            try
            {
                await _unitOfWork.GetRepository<TEntity>().AddBulkAsync(entities);
                await _unitOfWork.Complete();

                return entities;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Bulk Method {e.Message} in {e.StackTrace}");
                return Array.Empty<TEntity>();
            }
        }

        public override async Task<TEntity?> GetAsync(long id)
        {
            try
            {
                TEntity? entity = await _cacheService.GetByKeyAsync(id.ToString());
                if (entity is not null) {
                    return entity;
                }

                return await _unitOfWork.GetRepository<TEntity>().GetAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseCacheService in Get Method {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public override async Task<IList<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            try
            {
                if (await _cacheService.HasKeysAsync())
                {
                    return await _cacheService.GetAllAsync();
                }

                IList<TEntity> entities = await _unitOfWork.GetRepository<TEntity>().GetAllAsync(pageRequest);
                await SyncCache();

                return entities;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseCacheService in GetAll Method {e.Message} in {e.StackTrace}");
                return Array.Empty<TEntity>();
            }
        }

        protected async Task SyncCache()
        {
            PageRequest pageRequest = new PageRequest();
            pageRequest.PerPage = int.MaxValue;
            IList<TEntity> entities = await _unitOfWork.GetRepository<TEntity>().GetAllAsync(pageRequest);

            _ = _cacheService.InsertBulkAsync(entities);
        }
    }
}
