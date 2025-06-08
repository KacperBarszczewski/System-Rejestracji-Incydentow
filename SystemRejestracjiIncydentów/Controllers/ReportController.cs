using Microsoft.AspNetCore.Mvc;
using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Services;

namespace SystemRejestracjiIncydentów.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReportResultDto>> GenerateReport([FromBody] ReportRequestDto request)
        {
            var report = await _service.GenerateReportAsync(request);
            return Ok(report);
        }

    }
}
