// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Users.API.Models;
using Markway.Users.API.Repository.Core;

namespace Markway.Users.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<User>, IExampleEntityRepository
    {
        public ExampleEntityRepository(UsersContext context)
            : base(context) { }
    }
}
