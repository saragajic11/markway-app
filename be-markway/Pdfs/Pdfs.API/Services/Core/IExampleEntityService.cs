// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Pdfs.API.Models;
using Markway.Pdfs.API.Models.DTO;
namespace Markway.Pdfs.API.Services.Core
{
    public interface IPdfService
    {
        Task<Pdf?> AddAsync(ExampleEntityDto dto);

        Task<IList<Pdf>> GetAllAsync(PageRequest pageRequest);

        Task<Pdf?> GetAsync(long id);

        Task UploadPdf(IFormFile file);
        Task GenerateAndUploadPdf();
    }
}
