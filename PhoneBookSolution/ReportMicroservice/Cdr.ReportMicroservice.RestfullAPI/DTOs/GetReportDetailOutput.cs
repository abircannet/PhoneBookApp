using Cdr.ReportMicroservice.Domain.Entities;
using System.Text.Json.Serialization;

namespace Cdr.ReportMicroservice.RestfullAPI.DTOs
{
    public class GetReportDetailOutput
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReportStatus ReportStatus { get; set; }
        public string FilePath { get; set; }
    }
}
