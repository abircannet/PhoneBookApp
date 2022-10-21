using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Constants
{
    public class MessageServiceConst
    {
        public const string ReportExchangeName = "report-direct-exchange";
        public const string ReportExchangeType = "direct";
        public const string ReportRouting = "report-route-file";
        public const string ReportQueueName = "report-queue-file";
    }
}
