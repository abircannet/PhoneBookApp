using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IReportApiService
    { 
        Task<List<ReportDataDTO>> GetReportDataAsync(string location); 
        List<ReportDataDTO> GetReportData(string location);
    }
}
