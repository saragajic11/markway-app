// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Notification.API.Models.DTO;
using Markway.Notification.API.Repository.Core;
using Markway.Notification.API.Services.Core;
namespace Markway.Notification.API.Services
{
    public class BaseService<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;
        public BaseService()
        {
        }

        public BaseService(ILogger<BaseService<TEntity>> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity?> AddAsync(TEntity entity)
        {
            try
            {
                await _unitOfWork.GetRepository<TEntity>().AddAsync(entity);
                await _unitOfWork.Complete();

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public virtual async Task<IList<TEntity>> AddBulkAsync(IList<TEntity> entities)
        {
            try
            {
                await _unitOfWork.GetRepository<TEntity>().AddBulkAsync(entities);
                await _unitOfWork.Complete();

                return entities;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in AddBulk Method {e.Message} in {e.StackTrace}");
                return Array.Empty<TEntity>();
            }
        }


        public virtual async Task<TEntity?> GetAsync(long id)
        {
            try
            {
                return await _unitOfWork.GetRepository<TEntity>().GetAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Get Method {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            try
            {
                return await _unitOfWork.GetRepository<TEntity>().GetAllAsync(pageRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in GetAll Method {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
