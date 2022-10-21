using Cdr.ReportMicroservice.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IExcelReportService
    {
        Task<byte[]> CreateExcelAsync(SendReportRequestMessageDTO dto);
    }
}
