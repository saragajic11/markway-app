// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class ShipmentLoadOnLocationService : BaseService<ShipmentLoadOnLocation>, IShipmentLoadOnLocationService
    {
        private readonly IMapper _mapper;
        private readonly ILoadOnLocationService _loadOnLocationService;
        private readonly ICarrierService _carrierService;

        public ShipmentLoadOnLocationService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<ShipmentLoadOnLocationService> logger, ILoadOnLocationService loadOnLocationService, ICarrierService carrierService)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _loadOnLocationService = loadOnLocationService;
            _carrierService = carrierService;
        }

        public async Task<ShipmentLoadOnLocation?> AddAsync(ShipmentLoadOnLocationDto dto)
        {
            try
            {
                LoadOnLocation? loadOnLocation = await _loadOnLocationService.GetAsync((long)dto.LoadOnLocation.Id);
                ShipmentLoadOnLocation entity = _mapper.Map<ShipmentLoadOnLocation>(dto);
                entity.LoadOnLocation = loadOnLocation;
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
        public async Task<ShipmentLoadOnLocation?> GetAsync(long id)
        {
            try
            {
                ShipmentLoadOnLocation? shipmentLoadOnLocation = await _unitOfWork.ShipmentLoadOnLocations.GetAsync(id);
                return shipmentLoadOnLocation;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<IList<ShipmentLoadOnLocation>?> GetAsyncByShipmentId(long id)
        {
            try
            {
                IList<ShipmentLoadOnLocation>? shipmentLoadOnLocation = await _unitOfWork.ShipmentLoadOnLocations.GetAsyncByShipmentId(id);
                return shipmentLoadOnLocation;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<IList<ShipmentLoadOnLocation>?> GetAsyncByShipmentIdAndLoadOnLocationType(long id, long type)
        {
            try
            {
                IList<ShipmentLoadOnLocation>? shipmentLoadOnLocation = await _unitOfWork.ShipmentLoadOnLocations.GetAsyncByShipmentIdAndLoadOnLocationType(id, type);
                return shipmentLoadOnLocation;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<IList<ShipmentPopulatedDto?>> GetAllShipmentsPopulated(PageRequest pageRequest)
        {
            try
            {
                IList<Shipment>? shipments = await _unitOfWork.Shipments.GetAllAsync(pageRequest);
                List<ShipmentPopulatedDto> shipmentsPopulated = _mapper.Map<List<ShipmentPopulatedDto>>(shipments);
                foreach (ShipmentPopulatedDto? shipment in shipmentsPopulated)
                {

                    IList<ShipmentLoadOnLocation> shipmentLoadOnLocations = await GetAsyncByShipmentId(shipment.Id);
                    List<ShipmentLoadOnLocationSpecificDto> shipmentLoadOnLocationSpecificDtos = _mapper.Map<List<ShipmentLoadOnLocationSpecificDto>>(shipmentLoadOnLocations);
                    shipment.ShipmentLoadOnLocations = shipmentLoadOnLocationSpecificDtos;

                };

                return shipmentsPopulated;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
