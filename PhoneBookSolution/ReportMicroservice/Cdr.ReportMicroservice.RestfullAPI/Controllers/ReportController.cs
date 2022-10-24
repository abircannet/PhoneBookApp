using Cdr.ReportMicroservice.Domain.Interfaces;
using Cdr.ReportMicroservice.RestfullAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cdr.ReportMicroservice.RestfullAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var reports = await _reportService.GetAllAsync();
            if (!reports.Any())
                return NotFound();
            var dto = from q in reports
                      select new GetReportListOutput
                      {
                          Id = q.Id,
                          RequestDate = q.RequestTime,
                          ReportStatus = q.ReportStatus
                      };

            return Ok(dto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var report = await _reportService.GetAsync(id);
            if (report == null)
                return NotFound();
            var dto = new GetReportDetailOutput
            {
                Id = report.Id,
                RequestDate = report.RequestTime,
                ReportStatus = report.ReportStatus,
                FilePath = report.FilePath
            };

            return Ok(dto);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] string location)
        {
            await _reportService.CreateAsync(new Domain.DTOs.SendReportRequestMessageDTO { Location = location });
            return NoContent();
        }
    }
}