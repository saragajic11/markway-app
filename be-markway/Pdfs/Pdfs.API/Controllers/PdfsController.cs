using AutoMapper;
using Markway.Pdfs.API.Constants;
using Markway.Pdfs.API.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Markway.Pdfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfsController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        private readonly IMapper _mapper;

        public PdfsController(IPdfService pdfService, IMapper mapper)
        {
            _pdfService = pdfService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policy = Policies.Authorization.FILE_CREATE)]
        public async Task<IActionResult> UploadPdf([FromForm] IFormFile file)
        {
            await _pdfService.UploadPdf(file);

            return Ok();
        }

        [HttpPost(Endpoints.GENERATE_PDF)]
        // [Authorize(Policy = Policies.Authorization.FILE_CREATE)]
        public async Task<IActionResult> GeneratePdf()
        {
            await _pdfService.GenerateAndUploadPdf();

            return Ok();
        }
    }
}
