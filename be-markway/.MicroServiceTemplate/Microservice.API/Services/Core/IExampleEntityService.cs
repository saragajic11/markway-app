﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Microservice.API.Models;
using Napokon.Microservice.API.Models.DTO;
namespace Napokon.Microservice.API.Services.Core
{
    public interface IExampleEntityService
    {
        Task<ExampleEntity?> AddAsync(ExampleEntityDto dto);

        Task<IList<ExampleEntity>> GetAllAsync(PageRequest pageRequest);

        Task<ExampleEntity?> GetAsync(long id);

    }
}
