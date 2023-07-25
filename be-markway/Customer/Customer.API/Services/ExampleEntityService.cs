// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Customer.API.Models;
using Napokon.Customer.API.Models.DTO;
using Napokon.Customer.API.Repository.Core;
using Napokon.Customer.API.Services.Core;
namespace Napokon.Customer.API.Services
{
    public class EntityService : BaseService<CustomerEntity>, IExampleEntityService
    {
        private readonly IMapper _mapper;

        public EntityService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<EntityService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<CustomerEntity?> AddAsync(CustomerDto dto)
        {
            try
            {
                CustomerEntity entity = _mapper.Map<CustomerEntity>(dto);

                await base.AddAsync(entity);

                CustomerElasticDto entityElasticDto = _mapper.Map<CustomerElasticDto>(entity);
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
