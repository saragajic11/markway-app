﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Users.API.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();

        void Dispose();
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        IUserRepository Users { get; }
    }
}
