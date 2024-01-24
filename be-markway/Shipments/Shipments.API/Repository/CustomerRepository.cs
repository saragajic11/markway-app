// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Markway.Shipments.API.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShipmentsContext context)
            : base(context) { }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await ShipmentsContext.Customers
            .Where(customer => !customer.Deleted)
            .ToListAsync();
        }
    }
}
