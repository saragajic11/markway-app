// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Repository.Core;

namespace Napokon.Shipments.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShipmentsContext _context;

        private Dictionary<string, dynamic> _repositories = new();

        public ICustomerRepository Customers { get; private set; }

        public ICarrierRepository Carriers { get; private set; }

        public IBorderCrossingRepository BorderCrossings { get; private set; }


        public UnitOfWork(ShipmentsContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Carriers = new CarrierRepository(_context);
            BorderCrossings = new BorderCrossingRepository(_context);
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

        public ShipmentsContext Context => _context;

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

