﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Microservice.API.Models;
using Napokon.Microservice.API.Models.DTO;
using Napokon.Microservice.API.Repository.Core;
using Napokon.Microservice.API.Services.Core;
namespace Napokon.Microservice.API.Services
{
    public class EntityService : BaseService<ExampleEntity>, IExampleEntityService
    {
        private readonly IMapper _mapper;

        public EntityService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<EntityService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<ExampleEntity?> AddAsync(ExampleEntityDto dto)
        {
            try
            {
                ExampleEntity entity = _mapper.Map<ExampleEntity>(dto);

                await base.AddAsync(entity);

                ExampleEntityElasticDto entityElasticDto = _mapper.Map<ExampleEntityElasticDto>(entity);
                _elasticSearchService.IndexDocumentAsync(entityElasticDto);

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
