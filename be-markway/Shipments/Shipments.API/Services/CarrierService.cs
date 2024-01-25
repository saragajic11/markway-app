// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Models.DTO;
using Markway.Shipments.API.Repository.Core;
using Markway.Shipments.API.Services.Core;
namespace Markway.Shipments.API.Services
{
    public class CarrierService : BaseService<Carrier>, ICarrierService
    {
        private readonly IMapper _mapper;

        public CarrierService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<CarrierService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<Carrier?> AddAsync(CarrierDto dto)
        {
            try
            {
                Carrier entity = _mapper.Map<Carrier>(dto);

                await base.AddAsync(entity);

                CarrierElasticDto entityElasticDto = _mapper.Map<CarrierElasticDto>(entity);
                _elasticSearchService.IndexDocumentAsync(entityElasticDto);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Add {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<IList<Carrier>> GetAllAsync(PageRequest pageRequest)
        {
            try
            {
                IList<Carrier> listOfCarriers = await _unitOfWork.Carriers.GetAllAsync();
                return listOfCarriers;
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
                Carrier? carrier = await base.GetAsync(id);

                if (carrier is null)
                {
                    return false;
                }

                carrier.Deleted = true;

                await base.UpdateAsync(carrier);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return false;
            }
        }

        public async Task<Carrier> UpdateAsync(long id, CarrierDto carrierDto)
        {
            try
            {
                Carrier carrier = await _unitOfWork.Carriers.GetAsync(id);
                Carrier updatedCarrier = _unitOfWork.Carriers.Update(_mapper.Map(carrierDto, carrier));
                await _unitOfWork.Complete();

                return updatedCarrier;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Get {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
