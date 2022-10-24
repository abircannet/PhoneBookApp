using Cdr.ReportMicroservice.Domain.Interfaces;
using Core.DTOs;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

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
        public ReportDataDTO GetReportData(string location) => GetReportDataAsync(location).Result;

        public async Task<ReportDataDTO> GetReportDataAsync(string location) =>
            await _httpClient.GetFromJsonAsync<ReportDataDTO>($"{_configuration.GetSection("ContactMicroserviceUrl").Value}/contact/getreportdata/{location}");
    }
}
