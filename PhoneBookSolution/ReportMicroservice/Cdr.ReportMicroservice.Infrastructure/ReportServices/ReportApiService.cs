using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Entities;
using Cdr.ReportMicroservice.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Infrastructure.ReportServices
{
    public class ReportApiService : IReportApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ReportApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            this._configuration = configuration;
        }
        public  List<ReportDataDto> GetReportData() => GetReportDataAsync().Result;

        public async Task<List<ReportDataDto>> GetReportDataAsync() => await _httpClient.GetFromJsonAsync<List<ReportDataDto>>(_configuration.GetSection("ContactMicroserviceUrl").Value);
    }
}
