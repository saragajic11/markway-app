// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class ShipmentService : BaseService<Shipment>, IShipmentService
    {
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        private readonly ICustomerService _customerService;

        private readonly IRouteService _routeService;

        public ShipmentService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<ShipmentService> logger, ICustomerService customerService, INoteService noteService, IRouteService routeService)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _noteService = noteService;
            _customerService = customerService;
            _routeService = routeService;
        }

        public async Task<Shipment?> AddAsync(ShipmentDto dto)
        {
            try
            {
                Customer customer = await _customerService.GetAsync((long)dto.Customer.Id);
                Note note = await _noteService.GetAsync((long)dto.Note.Id);

                Shipment entity = _mapper.Map<Shipment>(dto);
                List<ShipmentsRoute> listOfShipmentRoutes = new();
                entity.Customer = customer;
                entity.Note = note;

                if (dto.ShipmentRoutes != null)
                {
                    foreach (RouteDto route in dto.ShipmentRoutes)
                    {
                        ShipmentsRoute shipmentsRoute = await _routeService.AddAsync(route);
                        if (shipmentsRoute != null)
                            listOfShipmentRoutes.Add(shipmentsRoute);
                    }
                }

                entity.ShipmentRoutes = listOfShipmentRoutes;


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

        public async Task<Shipment?> GetAsync(long id)
        {
            try
            {
                Shipment? shipment = await _unitOfWork.Shipments.GetAsync(id);
                return shipment;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
