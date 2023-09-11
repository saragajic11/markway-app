// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class BorderCrossingService : BaseService<BorderCrossing>, IBorderCrossingService
    {
        private readonly IMapper _mapper;

        public BorderCrossingService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<BorderCrossingService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<BorderCrossing?> AddAsync(BorderCrossingDto dto)
        {
            try
            {
                BorderCrossing entity = _mapper.Map<BorderCrossing>(dto);

                await base.AddAsync(entity);

                BorderCrossingElasticDto entityElasticDto = _mapper.Map<BorderCrossingElasticDto>(entity);
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
