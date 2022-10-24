namespace Cdr.ReportMicroservice.Domain.DTOs
{
    public class SendReportRequestMessageDTO
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public DateTime RequestDateTime { get; set; } = DateTime.UtcNow;
    }
}
