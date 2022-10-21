using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IMessageService
    {
        void SendMessage<T>(T message);

    }
}
