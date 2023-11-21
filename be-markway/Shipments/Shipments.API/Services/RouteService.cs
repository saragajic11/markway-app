// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class RouteService : BaseService<ShipmentsRoute>, IRouteService
    {
        private readonly IMapper _mapper;
        private readonly ICarrierService _carrierService;
        private readonly IShipmentService _shipmentService;

        public RouteService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<RouteService> logger, ICarrierService carrierService, IShipmentService shipmentService)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _carrierService = carrierService;
            _shipmentService = shipmentService;
        }

        public async Task<ShipmentsRoute?> AddAsync(RouteDto dto)
        {
            try
            {
                Carrier carrier = await _carrierService.GetAsync((long)dto.CarrierId);
                Shipment shipment = await _shipmentService.GetAsync((long)dto.ShipmentId);

                ShipmentsRoute entity = _mapper.Map<ShipmentsRoute>(dto);
                entity.Carrier = carrier;
                entity.Shipment = shipment;

                await base.AddAsync(entity);

                // ShipmentElasticDto entityElasticDto = _mapper.Map<ShipmentElasticDto>(entity);
                // _elasticSearchService.IndexDocumentAsync(entityElasticDto);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Add {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<ShipmentsRoute?> GetAsync(long id)
        {
            try
            {
                ShipmentsRoute? route = await _unitOfWork.Routes.GetAsync(id);
                return route;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
