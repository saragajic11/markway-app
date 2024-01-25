// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;

namespace Markway.Shipments.API.Repository.Core
{
    public interface ICarrierRepository : IBaseRepository<Carrier>
    {
        public Task<IList<Carrier>> GetAllAsync();
    }
}

