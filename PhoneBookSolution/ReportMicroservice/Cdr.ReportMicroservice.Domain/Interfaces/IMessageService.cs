namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IMessageService
    {
        void SendMessage<T>(T message);

    }
}
