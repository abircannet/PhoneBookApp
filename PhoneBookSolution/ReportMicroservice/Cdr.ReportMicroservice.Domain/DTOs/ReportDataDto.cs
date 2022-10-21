using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.DTOs
{
    public class ReportDataDto
    {
        public string Location { get; set; }

        public int PersonCount { get; set; }

        public int PhoneCount { get; set; }
    }
}
