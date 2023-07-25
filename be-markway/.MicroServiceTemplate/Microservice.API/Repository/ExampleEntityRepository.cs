// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Microservice.API.Models;
using Napokon.Microservice.API.Repository.Core;

namespace Napokon.Microservice.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(MicroserviceContext context)
            : base(context) { }
    }
}
