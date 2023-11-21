// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Repository.Core;

namespace Markway.Shipments.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShipmentsContext _context;

        private Dictionary<string, dynamic> _repositories = new();

        public ICustomerRepository Customers { get; private set; }

        public ICarrierRepository Carriers { get; private set; }

        public IBorderCrossingRepository BorderCrossings { get; private set; }

        public ICustomsRepository Customs { get; private set; }

        public ILoadOnLocationRepository LoadOnLocation { get; private set; }

        public INoteRepository Notes { get; private set; }

        public IShipmentRepository Shipments { get; private set; }

        public IShipmentLoadOnLocationRepository ShipmentLoadOnLocations { get; private set; }

        public IShipmentCustomRepository ShipmentCustoms { get; private set; }

        public IRouteRepository Routes { get; private set; }

        public UnitOfWork(ShipmentsContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Carriers = new CarrierRepository(_context);
            BorderCrossings = new BorderCrossingRepository(_context);
            Customs = new CustomsRepository(_context);
            LoadOnLocation = new LoadOnLocationRepository(_context);
            Notes = new NoteRepository(_context);
            ShipmentLoadOnLocations = new ShipmentLoadOnLocationRepository(_context);
            ShipmentCustoms = new ShipmentCustomRepository(_context);
            Shipments = new ShipmentRepository(_context);
            Routes = new RouteRepository(_context);
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

