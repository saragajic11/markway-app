// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class CustomsService : BaseService<Customs>, ICustomsService
    {
        private readonly IMapper _mapper;

        public CustomsService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<CustomsService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<Customs?> AddAsync(CustomsDto dto)
        {
            try
            {
                Customs entity = _mapper.Map<Customs>(dto);

                await base.AddAsync(entity);

                CustomsElasticDto entityElasticDto = _mapper.Map<CustomsElasticDto>(entity);
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
