// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

using Markway.Notification.API.Models;
using Markway.Notification.API.Models.DTO;
using Markway.Notification.API.Repository.Core;

namespace Markway.Notification.API.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public NotificationContext NotificationContext => _context as NotificationContext;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task AddBulkAsync(IList<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual async Task<TEntity?> GetAsync(long id) => await _context.Set<TEntity>().FindAsync(id);

        public virtual async Task<IList<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            if (Sort.DESC.Equals(pageRequest.Sort))
            {
                return await _context.Set<TEntity>()
                    .OrderByDescending(entity => (entity as Entity).Id)
                    .Skip(pageRequest.Page * pageRequest.PerPage)
                    .Take(pageRequest.PerPage)
                    .ToListAsync();
            }

            return await _context.Set<TEntity>()
                    .OrderBy(entity => (entity as Entity).Id)
                    .Skip(pageRequest.Page * pageRequest.PerPage)
                    .Take(pageRequest.PerPage)
                    .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Detach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}

