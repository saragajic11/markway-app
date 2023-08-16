// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
using Napokon.Shipments.API.Repository.Core;
using Napokon.Shipments.API.Services.Core;
namespace Napokon.Shipments.API.Services
{
    public class LoadOnLocationService : BaseService<LoadOnLocation>, ILoadOnLocationService
    {
        private readonly IMapper _mapper;

        public LoadOnLocationService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<LoadOnLocationService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<LoadOnLocation?> AddAsync(LoadOnLocationDto dto)
        {
            try
            {
                LoadOnLocation entity = _mapper.Map<LoadOnLocation>(dto);

                await base.AddAsync(entity);

                LoadOnLocationElasticDto entityElasticDto = _mapper.Map<LoadOnLocationElasticDto>(entity);
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
