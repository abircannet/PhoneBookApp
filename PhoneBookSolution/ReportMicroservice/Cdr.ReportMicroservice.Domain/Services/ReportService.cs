using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Entities;
using Cdr.ReportMicroservice.Domain.Interfaces;
using Core.Interfaces;

namespace Cdr.ReportMicroservice.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> _repository;
        private readonly IMessageService _messageService;

        public ReportService(IRepository<Report> repository, IMessageService messageService)
        {
            _repository = repository;
            this._messageService = messageService;
        }

        public async Task CreateAsync(SendReportRequestMessageDTO dto)
        {
            try
            {
                var report = await _repository.AddAsync(new Report() { ReportStatus = ReportStatus.Continues, RequestTime = dto.RequestDateTime });
                dto.Id = report.Id;
                _messageService.SendMessage(dto);
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<IReadOnlyCollection<Report>> GetAllAsync()
        {
            return (await _repository.ListAsync()).AsReadOnly();
        }

        public async Task<Report> GetAsync(string id)
        {
            return await _repository.GetByIdAsync(Guid.Parse(id));

        }
    }
}
