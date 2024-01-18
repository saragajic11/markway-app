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
using UsersService;
using Markway.Pdfs.API.Services.Grpc.Clients;
using Markway.Notification.API.Grpc;
using System.Text;
using Newtonsoft.Json;
namespace Markway.Pdfs.API.Services
{
    public class PdfService : BaseService<Pdf>, IPdfService
    {
        private readonly IMapper _mapper;
        private readonly SystemConfiguration _systemConfiguration;
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationClient _notificationClient;
        private readonly string _extension = ".pdf";

        public PdfService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork,
        ILogger<PdfService> logger, SystemConfiguration systemConfiguration,
        ICurrentUserService currentUserService, INotificationClient notificationClient)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
            _systemConfiguration = systemConfiguration;
            _currentUserService = currentUserService;
            _notificationClient = notificationClient;
        }

        public async Task<Pdf?> AddAsync(PdfDto dto)
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

        public async Task GenerateAndUploadPdf(ShipmentMailDto dto)
        {
            UserReply user = await _currentUserService.GetCurrentUserAsync();

            try
            {
                using HttpClient httpClient = new();
                string resolvedPdf = await ResolveMarkwayPdfTemplate(dto);

                var payload = new
                {
                    html_string = resolvedPdf
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(_systemConfiguration.GeneratePdfApi, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the PDF content from the response
                    byte[] pdfContent = await response.Content.ReadAsByteArrayAsync();

                    await using (var memoryStream = new MemoryStream(pdfContent))
                    {
                        // Provide the filename and content type (for example, "application/pdf")
                        const string contentType = "application/pdf";

                        // Call the UploadPdf method with the MemoryStream
                        await UploadPdf(memoryStream, contentType);
                    }

                    EmailRequest request = new()
                    {
                        SendToAddress = "milos.markovic@markwaylog.com",
                        Body = resolvedPdf
                    };

                    await _notificationClient.SendPdfEmailAsync(request);
                }
                else
                {
                    return;
                }
            }
            catch(Exception e)
            {
                _logger.LogError($"Error in PdfService in GenerateAndUploadPdf {e.Message} in {e.StackTrace}");
                return;
            }
        }

        private async Task UploadPdf(Stream fileStream, string contentType)
        {
            if (fileStream == null || fileStream.Length == 0)
            {
                return;
            }

            try
            {
                using (var client = new AmazonS3Client(_systemConfiguration.S3Settings.AccessKey, _systemConfiguration.S3Settings.AccessSecret, RegionEndpoint.GetBySystemName(_systemConfiguration.S3Settings.Region)))
                {
                    var key = Guid.NewGuid() + "_generatedPdf" + Guid.NewGuid(); // Unique key for the S3 object

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

        private async Task<string> ResolveMarkwayPdfTemplate(ShipmentMailDto dto)
        {
            string baseTemplate = await ResolvePdfTemplate(PdfTemplate.GENERATE_PDF);

            string updatedTemplate = baseTemplate
                .Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_ID, dto.Id.ToString());

            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_CARRIER, dto.Carrier);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_LICENCE_PLATE, dto.LicencePlate);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_VEHICLE_TYPE, dto.VehicleType);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_MERCH, dto.Merch);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_AMOUNT, dto.Amount);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_LOAD_ON_LOCATION, dto.LoadOnLocation);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_LOAD_ON_DATE, dto.LoadOnDate);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_LOAD_OFF_DATE, dto.LoadOffDate);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_EXPORT_CUSTOMS, dto.ExportCustoms);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_IMPORT_CUSTOMS, dto.ImportCustoms);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_LOAD_OFF_LOCATION, dto.LoadOffLocation);
            updatedTemplate = updatedTemplate.Replace(PdfTemplateKeys.MARKWAY_SHIPMENT_NOTES, dto.Notes);

            return updatedTemplate;
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

        public async Task<Pdf?> UploadPdf(IFormFile file, PdfDto pdfDto)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            try
            {
                using var client = new AmazonS3Client(_systemConfiguration.S3Settings.AccessKey, _systemConfiguration.S3Settings.AccessSecret, RegionEndpoint.GetBySystemName(_systemConfiguration.S3Settings.Region));
                string key = Guid.NewGuid() + Path.GetExtension(file.FileName); // Unique key for the S3 object
                DateTime now = DateTime.Now;
                string path = string.Format("/markway/{0}/{1}/{2}", now.Year, now.Month, now.Day);

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
                        Path = path + "/" + key,
                        Extension = _extension,
                        ReferenceId = pdfDto.ReferenceId,
                    };

                    return await base.AddAsync(pdf);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in PdfService in UploadPdf {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
