// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customer.API.Models;
using Napokon.Customer.API.Repository.Core;

namespace Napokon.Customer.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(CustomerContext context)
            : base(context) { }
    }
}
