// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Shipments.API.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();

        void Dispose();
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        ICustomerRepository Customers { get; }

        ICarrierRepository Carriers { get; }

        IBorderCrossingRepository BorderCrossings { get; }

        ICustomsRepository Customs { get; }

        ILoadOnLocationRepository LoadOnLocation { get; }

        INoteRepository Notes { get; }

    }
}

