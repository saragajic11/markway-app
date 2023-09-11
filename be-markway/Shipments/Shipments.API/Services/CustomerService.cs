// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<CustomerService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<Customer?> AddAsync(CustomerDto dto)
        {
            try
            {
                Customer entity = _mapper.Map<Customer>(dto);

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
