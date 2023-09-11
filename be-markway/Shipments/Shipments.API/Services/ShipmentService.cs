// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
using Napokon.Shipments.API.Repository.Core;
using Napokon.Shipments.API.Services.Core;
namespace Napokon.Shipments.API.Services
{
    public class ShipmentService : BaseService<Shipment>, IShipmentService
    {
        private readonly IMapper _mapper;

        public ShipmentService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<ShipmentService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<Shipment?> AddAsync(ShipmentDto dto)
        {
            try
            {
                Shipment entity = _mapper.Map<Shipment>(dto);

                await base.AddAsync(entity);

                ShipmentElasticDto entityElasticDto = _mapper.Map<ShipmentElasticDto>(entity);
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
