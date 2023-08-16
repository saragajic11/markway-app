// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Napokon.Shipments.API.Models;
using Napokon.Shipments.API.Models.DTO;
using Napokon.Shipments.API.Repository.Core;
using Napokon.Shipments.API.Services.Core;
namespace Napokon.Shipments.API.Services
{
    public class NoteService : BaseService<Note>, INoteService
    {
        private readonly IMapper _mapper;

        public NoteService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<NoteService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<Note?> AddAsync(NoteDto dto)
        {
            try
            {
                Note entity = _mapper.Map<Note>(dto);

                await base.AddAsync(entity);

                NoteElasticDto entityElasticDto = _mapper.Map<NoteElasticDto>(entity);
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
