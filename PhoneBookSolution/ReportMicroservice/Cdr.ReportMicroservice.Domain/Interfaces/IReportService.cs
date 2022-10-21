using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IReportService
    {
        Task<IReadOnlyCollection<Report>> GetAllAsync();
        Task<Report> GetAsync(string id);
        void Create(SendReportRequestMessageDTO dto);
    }
}
