using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Services
{
    public class ExcelReportService : IExcelReportService
    {
        private readonly IReportApiService _reportApiService;

        public ExcelReportService(IReportApiService reportApiService)
        {
            _reportApiService = reportApiService;
        }

        public async Task<byte[]> CreateExcelAsync(SendReportRequestMessageDTO dto)
        {
            
            var reportData = await _reportApiService.GetReportDataAsync(dto.Location);
            using var package = new ExcelPackage();
            var reportSheet = package.Workbook.Worksheets.Add("Location Report");

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
            foreach (var item in reportData)
            {
                reportSheet.Cells[rowIndex, 1].Value = item.Location;
                reportSheet.Cells[rowIndex, 2].Value = item.PersonCount;
                reportSheet.Cells[rowIndex, 3].Value = item.PhoneCount;
            }

            #endregion

            return package.GetAsByteArray();
        }
    }
}
