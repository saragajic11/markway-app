// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Users.API.Models;
using Markway.Users.API.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Markway.Users.API.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UsersContext context)
            : base(context) { }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await UsersContext.Users
                .OrderByDescending(user => user.DateCreated)
                .FirstOrDefaultAsync(user => (username.Equals(user.Username) || username.Equals(user.Email))
                && !user.Deleted);
        }
    }
}
