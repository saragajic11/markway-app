// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
namespace Markway.Shipments.API.Services.Core
{
    public interface ICarrierService
    {
        Task<Carrier?> AddAsync(CarrierDto dto);

        Task<IList<Carrier>> GetAllAsync(PageRequest pageRequest);

        Task<Carrier?> GetAsync(long id);
    }
}
