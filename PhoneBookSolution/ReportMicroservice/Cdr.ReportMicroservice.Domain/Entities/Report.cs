using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Entities
{
    public class Report:BaseEntity
    {
        public DateTime RequestTime { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string FilePath { get; set; }
    }
}
