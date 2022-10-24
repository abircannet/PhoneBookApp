using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Entities;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IReportService
    {
        Task<IReadOnlyCollection<Report>> GetAllAsync();
        Task<Report> GetAsync(string id);
        Task CreateAsync(SendReportRequestMessageDTO dto);
    }
}
