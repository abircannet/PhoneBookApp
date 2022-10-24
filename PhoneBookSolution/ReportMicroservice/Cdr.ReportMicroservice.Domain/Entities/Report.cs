using Core.Base;

namespace Cdr.ReportMicroservice.Domain.Entities
{
    public class Report : BaseEntity
    {
        public DateTime RequestTime { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string FilePath { get; set; }
    }
}
