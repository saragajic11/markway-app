// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

using Markway.Pdfs.API.Models;
using Markway.Pdfs.API.Models.DTO;
using Markway.Pdfs.API.Repository.Core;
using Markway.Pdfs.API.Services.Core;
using Markway.Commons.Configurations;
namespace Markway.Pdfs.API.Services
{
    public class PdfService : BaseService<ExampleEntity>, IExampleEntityService
    {
        private readonly IMapper _mapper;
        private readonly SystemConfiguration _systemConfiguration;

        public PdfService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<PdfService> logger, SystemConfiguration systemConfiguration)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _systemConfiguration = systemConfiguration;
        }

        public async Task<ExampleEntity?> AddAsync(ExampleEntityDto dto)
        {
            try
            {
                ExampleEntity entity = _mapper.Map<ExampleEntity>(dto);

                await base.AddAsync(entity);

                ExampleEntityElasticDto entityElasticDto = _mapper.Map<ExampleEntityElasticDto>(entity);
                _elasticSearchService.IndexDocumentAsync(entityElasticDto);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EntityService in Add {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return;
            }

            try
            {
                using (var client = new AmazonS3Client(_systemConfiguration.S3Settings.AccessKey, _systemConfiguration.S3Settings.AccessSecret, RegionEndpoint.GetBySystemName(_systemConfiguration.S3Settings.Region)))
                {
                    var key = Guid.NewGuid() + Path.GetExtension(file.FileName); // Unique key for the S3 object

                    using (var fileStream = file.OpenReadStream())
                    {
                        var putRequest = new PutObjectRequest
                        {
                            BucketName = _systemConfiguration.S3Settings.Bucket,
                            Key = key,
                            InputStream = fileStream,
                            ContentType = file.ContentType
                        };

                        var response = await client.PutObjectAsync(putRequest);

                        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
