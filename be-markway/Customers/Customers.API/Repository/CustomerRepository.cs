// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customers.API.Models;
using Napokon.Customers.API.Repository.Core;

namespace Napokon.Customers.API.Repository
{
    public class CustomeRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomeRepository(CustomersContext context)
            : base(context) { }
    }
}
