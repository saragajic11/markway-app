// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class ShipmentCustomService : BaseService<ShipmentCustoms>, IShipmentCustomService
    {
        private readonly IMapper _mapper;
        private readonly ICustomsService _customsService;

        public ShipmentCustomService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<ShipmentCustomService> logger, ICustomsService customsService)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _customsService = customsService;
        }

        public async Task<ShipmentCustoms?> AddAsync(ShipmentCustomDto dto)
        {
            try
            {
                Customs? custom = await _customsService.GetAsync((long)dto.Custom.Id);
                ShipmentCustoms entity = _mapper.Map<ShipmentCustoms>(dto);
                entity.Custom = custom;
                await base.AddAsync(entity);

                // ShipmentLoadOnLocationElasticDto entityElasticDto = _mapper.Map<ShipmentLoadOnLocationElasticDto>(entity);
                // _elasticSearchService.IndexDocumentAsync(entityElasticDto);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Add {e.Message} in {e.StackTrace}");
                return null;
            }
        }
        public async Task<ShipmentCustoms?> GetAsync(long id)
        {
            try
            {
                ShipmentCustoms? shipmentCustoms = await _unitOfWork.ShipmentCustoms.GetAsync(id);
                return shipmentCustoms;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
