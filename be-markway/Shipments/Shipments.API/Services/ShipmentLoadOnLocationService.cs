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
        private readonly IShipmentService _shipmentService;
        private readonly ILoadOnLocationService _loadOnLocationService;

        public ShipmentLoadOnLocationService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<ShipmentLoadOnLocationService> logger, IShipmentService shipmentService, ILoadOnLocationService loadOnLocationService)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _shipmentService = shipmentService;
            _loadOnLocationService = loadOnLocationService;
        }

        public async Task<ShipmentLoadOnLocation?> AddAsync(ShipmentLoadOnLocationDto dto)
        {
            try
            {
                Shipment? shipment = await _shipmentService.GetAsync((long)dto.ShipmentId);
                LoadOnLocation? loadOnLocation = await _loadOnLocationService.GetAsync((long)dto.LoadOnLocationId);
                ShipmentLoadOnLocation entity = _mapper.Map<ShipmentLoadOnLocation>(dto);
                entity.Shipment = shipment;
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
    }
}
