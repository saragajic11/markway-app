// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Customers.API.Models;
using Napokon.Customers.API.Models.DTO;
namespace Napokon.Customers.API.Services.Core
{
    public interface IExampleEntityService
    {
        Task<Customer?> AddAsync(ExampleEntityDto dto);

        Task<IList<Customer>> GetAllAsync(PageRequest pageRequest);

        Task<Customer?> GetAsync(long id);

    }
}
