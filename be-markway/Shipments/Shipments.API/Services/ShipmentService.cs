// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
using UsersService;
namespace Markway.Shipments.API.Services
{
    public class ShipmentService : BaseService<Shipment>, IShipmentService
    {
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        private readonly ICustomerService _customerService;
        private readonly IRouteService _routeService;
        private readonly ICurrentUserService _currentUserService;

        public ShipmentService(IMapper mapper, IElasticSearchService elasticSearchService,
        IUnitOfWork unitOfWork,
        ILogger<ShipmentService> logger,
        ICustomerService customerService,
        INoteService noteService,
        IRouteService routeService,
        ICurrentUserService currentUserService)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _noteService = noteService;
            _customerService = customerService;
            _routeService = routeService;
            _currentUserService = currentUserService;
        }

        public async Task<Shipment?> AddAsync(ShipmentDto dto)
        {
            try
            {
                UserReply user = await _currentUserService.GetCurrentUserAsync();

                Customer customer = await _customerService.GetAsync((long)dto.Customer.Id);
                Note note = await _noteService.GetAsync((long)dto.Note.Id);

                Shipment entity = _mapper.Map<Shipment>(dto);
                List<ShipmentsRoute> listOfShipmentRoutes = new();
                entity.Customer = customer;
                entity.Note = note;
                entity.UserId = user.Id;

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
                return await _unitOfWork.Shipments.GetAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                Shipment? shipment = await base.GetAsync(id);

                if(shipment is null)
                {
                    return false;
                }

                shipment.Deleted = true;

                await base.UpdateAsync(shipment);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return false;
            }
        }

        public async Task<IList<Shipment>> GetAllAsync(ShipmentFilter filter)
        {
            try
            {
                UserReply user = await _currentUserService.GetCurrentUserAsync();

                filter.UserId = user.Id;

                IList<Shipment> listOfShipments = await _unitOfWork.Shipments.GetAllAsync(filter);
                foreach (var shipment in listOfShipments)
                {
                    foreach (var route in shipment.ShipmentRoutes)
                    {
                        route.ShipmentLoadOnLocations = route.ShipmentLoadOnLocations
                        .OrderBy(shipmentLoadOnLocation => shipmentLoadOnLocation.type)
                        .ThenBy(shipmentLoadOnLocation => shipmentLoadOnLocation.date)
                        .ToList();
                    }
                }
                return listOfShipments;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
