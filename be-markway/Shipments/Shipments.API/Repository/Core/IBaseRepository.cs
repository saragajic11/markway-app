// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
using Napokon.Shipments.API.Models.DTO;

namespace Napokon.Shipments.API.Repository.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task AddBulkAsync(IList<TEntity> entity);

        Task<TEntity?> GetAsync(long id);

        Task<IList<TEntity>> GetAllAsync(PageRequest pageRequest);

        Task SaveChangesAsync();

    }
}

