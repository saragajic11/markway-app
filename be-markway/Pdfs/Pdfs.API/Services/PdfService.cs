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
using PuppeteerSharp;
using Markway.Pdfs.API.Errors;
using System.Net;
namespace Markway.Pdfs.API.Services
{
    public class PdfService : BaseService<Pdf>, IPdfService
    {
        private readonly IMapper _mapper;
        private readonly SystemConfiguration _systemConfiguration;

        public PdfService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<PdfService> logger, SystemConfiguration systemConfiguration)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _systemConfiguration = systemConfiguration;
        }

        public async Task<Pdf?> AddAsync(ExampleEntityDto dto)
        {
            try
            {
                Pdf entity = _mapper.Map<Pdf>(dto);

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

        public async Task GenerateAndUploadPdf()
        {
            try
            {
                await new BrowserFetcher().DownloadAsync();

                using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = new[] { "--no-sandbox" } // This is needed for running in certain environments, like Linux containers
                }))
                using (var page = await browser.NewPageAsync())
                {
                    // Generate PDF content
                    await page.SetContentAsync(await ResolvePdfTemplate(PdfTemplate.GENERATE_PDF));

                    // Convert PDF content to a stream
                    var pdfStream = await page.PdfStreamAsync();

                    // Upload the generated PDF to S3
                    await UploadPdf(pdfStream, "generated.pdf", "application/pdf");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in PdfService in GenerateAndUploadPdf {e.Message} in {e.StackTrace}");
            }
        }

        private async Task UploadPdf(Stream fileStream, string fileName, string contentType)
        {
            if (fileStream == null || fileStream.Length == 0)
            {
                return;
            }

            try
            {
                using (var client = new AmazonS3Client(_systemConfiguration.S3Settings.AccessKey, _systemConfiguration.S3Settings.AccessSecret, RegionEndpoint.GetBySystemName(_systemConfiguration.S3Settings.Region)))
                {
                    var key = Guid.NewGuid() + Path.GetExtension(fileName); // Unique key for the S3 object

                    var putRequest = new PutObjectRequest
                    {
                        BucketName = _systemConfiguration.S3Settings.Bucket,
                        Key = key,
                        InputStream = fileStream,
                        ContentType = contentType
                    };

                    var response = await client.PutObjectAsync(putRequest);

                    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return;
                    }
                    else
                    {
                        _logger.LogError($"Error uploading PDF to S3. HttpStatusCode: {response.HttpStatusCode}");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in PdfService in UploadPdf {e.Message} in {e.StackTrace}");
                return;
            }
        }

        private static async Task<string> ResolvePdfTemplate(PdfTemplate pdfTemplate)
        {
            string? templatePath = PdfTemplates.Paths.GetValueOrDefault(pdfTemplate);
            if (templatePath is not null)
            {
                return await File.ReadAllTextAsync(templatePath);
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest, new ErrorResponse(ErrorCode.SERVICE_ABBREVIATION_0001));
        }

        public async Task UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return;
            }

            try
            {
                using var client = new AmazonS3Client(_systemConfiguration.S3Settings.AccessKey, _systemConfiguration.S3Settings.AccessSecret, RegionEndpoint.GetBySystemName(_systemConfiguration.S3Settings.Region));
                var key = Guid.NewGuid() + Path.GetExtension(file.FileName); // Unique key for the S3 object

                await using var fileStream = file.OpenReadStream();
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
                    Pdf pdf = new()
                    {
                        Name = key,
                    };
                    
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
