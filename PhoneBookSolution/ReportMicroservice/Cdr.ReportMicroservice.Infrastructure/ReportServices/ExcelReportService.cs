using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Entities;
using Cdr.ReportMicroservice.Domain.Interfaces;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System.Drawing;

namespace Cdr.ReportMicroservice.Domain.Services
{
    public class ExcelReportService : IExcelReportService
    {
        private readonly IReportApiService _reportApiService;
        private readonly IServiceProvider _serviceProvider;

        public ExcelReportService(IReportApiService reportApiService, IServiceProvider serviceProvider)

        {
            _reportApiService = reportApiService;
            _serviceProvider = serviceProvider;
        }

        public async Task CreateExcelAsync(SendReportRequestMessageDTO dto)
        {

            var reportData = await _reportApiService.GetReportDataAsync(dto.Location);
            using var package = new ExcelPackage();
            var reportSheet = package.Workbook.Worksheets.Add("Location_Report");

            #region Create Column Title

            reportSheet.Cells[1, 1].Value = "Location";
            reportSheet.Cells[1, 2].Value = "Person Count";
            reportSheet.Cells[1, 3].Value = "Phone Count";
            reportSheet.Cells[1, 1, 1, 3].Style.Font.Bold = true;
            reportSheet.Cells[1, 1, 1, 3].Style.Font.Color.SetColor(Color.White);
            reportSheet.Cells[1, 1, 1, 3].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            reportSheet.Cells[1, 1, 1, 3].Style.Fill.BackgroundColor.SetColor(Color.Black);
            reportSheet.Cells[1, 1, 1, 3].AutoFilter = true;
            reportSheet.Column(1).AutoFit();
            reportSheet.Column(2).AutoFit();
            reportSheet.Column(3).AutoFit();
            reportSheet.Row(1).Height = 16f;

            #endregion

            #region Create Report Content

            var rowIndex = 2;

            reportSheet.Cells[rowIndex, 1].Value = reportData.Location;
            reportSheet.Cells[rowIndex, 2].Value = reportData.PersonCount;
            reportSheet.Cells[rowIndex, 3].Value = reportData.PhoneCount;


            #endregion


            var fileName = Guid.NewGuid().ToString() + ".xlsx";
            var saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/reports");
            var savePath = Path.Combine(saveDirectory, fileName);
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
            await package.SaveAsAsync(savePath);


            #region Update Report From DB
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IRepository<Report> _reportRepository =
                    scope.ServiceProvider.GetRequiredService<IRepository<Report>>();

                var report = await _reportRepository.GetByIdAsync(dto.Id);
                report.FilePath = savePath;
                report.ReportStatus = ReportStatus.Completed;
                await _reportRepository.UpdateAsync(report);


            }
            #endregion

        }
    }
}
