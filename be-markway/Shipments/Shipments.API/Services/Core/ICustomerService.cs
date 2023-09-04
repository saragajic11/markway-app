// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
namespace Markway.Shipments.API.Services.Core
{
    public interface ICustomerService
    {
        Task<Customer?> AddAsync(CustomerDto dto);

        Task<IList<Customer>> GetAllAsync(PageRequest pageRequest);

        Task<Customer?> GetAsync(long id);
    }
}
