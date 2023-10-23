// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Users.API.Models;
using Markway.Users.API.Models.DTO;
namespace Markway.Users.API.Services.Core
{
    public interface IUserService
    {
        Task<User?> AddAsync(UserDto dto);

        Task<IList<User>> GetAllAsync(PageRequest pageRequest);

        Task<User?> GetAsync(long id);

    }
}
