// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class CarrierService : BaseService<Carrier>, ICarrierService
    {
        private readonly IMapper _mapper;

        public CarrierService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<CarrierService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<Carrier?> AddAsync(CarrierDto dto)
        {
            try
            {
                Carrier entity = _mapper.Map<Carrier>(dto);

                await base.AddAsync(entity);

                CarrierElasticDto entityElasticDto = _mapper.Map<CarrierElasticDto>(entity);
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
