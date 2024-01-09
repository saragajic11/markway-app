// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Notification.API.Models;
using Markway.Notification.API.Models.DTO;
using Markway.Notification.API.Repository.Core;
using Markway.Notification.API.Services.Core;
namespace Markway.Notification.API.Services
{
    public class EntityService : BaseService<ExampleEntity>, IExampleEntityService
    {
        private readonly IMapper _mapper;

        public EntityService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<EntityService> logger)
            : base(logger, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<ExampleEntity?> AddAsync(ExampleEntityDto dto)
        {
            try
            {
                ExampleEntity entity = _mapper.Map<ExampleEntity>(dto);

                await base.AddAsync(entity);

                ExampleEntityElasticDto entityElasticDto = _mapper.Map<ExampleEntityElasticDto>(entity);

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
