// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Pdfs.API.Models;
using Markway.Pdfs.API.Models.DTO;
namespace Markway.Pdfs.API.Services.Core
{
    public interface IExampleEntityService
    {
        Task<ExampleEntity?> AddAsync(ExampleEntityDto dto);

        Task<IList<ExampleEntity>> GetAllAsync(PageRequest pageRequest);

        Task<ExampleEntity?> GetAsync(long id);

        Task UploadPdf(IFormFile file);
    }
}
