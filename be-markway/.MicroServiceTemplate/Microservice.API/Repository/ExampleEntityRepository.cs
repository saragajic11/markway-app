// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Microservice.API.Models;
using Markway.Microservice.API.Repository.Core;

namespace Markway.Microservice.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(MicroserviceContext context)
            : base(context) { }
    }
}
