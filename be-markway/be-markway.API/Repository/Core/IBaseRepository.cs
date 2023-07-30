// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
using Napokon.be_markway.API.Models.DTO;

namespace Napokon.be_markway.API.Repository.Core
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

