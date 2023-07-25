// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customer.API.Models;
using Napokon.Customer.API.Repository.Core;

namespace Napokon.Customer.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext _context;

        private Dictionary<string, dynamic> _repositories = new();

        public IExampleEntityRepository Entities { get; private set; }

        public UnitOfWork(CustomerContext context)
        {
            _context = context;
            Entities = new ExampleEntityRepository(_context);
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            string type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            Type repositoryType = typeof(BaseRepository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }

        public CustomerContext Context => _context;

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}

