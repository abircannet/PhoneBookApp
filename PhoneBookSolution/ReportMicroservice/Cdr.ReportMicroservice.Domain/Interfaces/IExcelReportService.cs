using Cdr.ReportMicroservice.Domain.DTOs;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IExcelReportService
    {
        Task CreateExcelAsync(SendReportRequestMessageDTO dto);
    }
}
