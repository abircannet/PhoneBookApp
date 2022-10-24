namespace Cdr.ReportMicroservice.Domain.Interfaces
{
    public interface IReporterClientService<T> : IDisposable
    {
        public T Connect();

    }
}
