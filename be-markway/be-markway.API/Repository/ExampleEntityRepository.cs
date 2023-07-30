// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.be_markway.API.Models;
using Napokon.be_markway.API.Repository.Core;

namespace Napokon.be_markway.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(be_markwayContext context)
            : base(context) { }
    }
}
