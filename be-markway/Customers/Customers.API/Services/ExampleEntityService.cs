﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Customers.API.Models;
using Napokon.Customers.API.Models.DTO;
using Napokon.Customers.API.Repository.Core;
using Napokon.Customers.API.Services.Core;
namespace Napokon.Customers.API.Services
{
    public class EntityService : BaseService<Customer>, IExampleEntityService
    {
        private readonly IMapper _mapper;

        public EntityService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<EntityService> logger)
            : base(logger, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<Customer?> AddAsync(ExampleEntityDto dto)
        {
            try
            {
                Customer entity = _mapper.Map<Customer>(dto);

                await base.AddAsync(entity);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Add {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
