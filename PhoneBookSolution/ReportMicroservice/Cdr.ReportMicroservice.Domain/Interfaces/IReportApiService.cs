using Core.DTOs;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IReportApiService
    {
        Task<ReportDataDTO> GetReportDataAsync(string location);
        ReportDataDTO GetReportData(string location);
    }
}
