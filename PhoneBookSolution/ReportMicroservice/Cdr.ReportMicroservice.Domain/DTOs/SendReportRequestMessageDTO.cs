using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.DTOs
{
    public class SendReportRequestMessageDTO
    {
        public string Location { get; set; }
        public DateTime RequestDateTime { get; set; }=DateTime.UtcNow;
    }
}
