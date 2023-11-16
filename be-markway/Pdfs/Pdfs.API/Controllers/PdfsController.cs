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
        private readonly IExampleEntityService _entityService;
        private readonly IMapper _mapper;

        public PdfsController(IExampleEntityService entityService, IMapper mapper)
    {
        _entityService = entityService;
        _mapper = mapper;
    }

        [HttpPost]
        [Authorize(Policy = Policies.Authorization.FILE_CREATE)]
        public async Task<IActionResult> UploadPdf([FromForm] IFormFile file)
        {
            await _entityService.UploadPdf(file);

            return Ok();
        }
    }
}
