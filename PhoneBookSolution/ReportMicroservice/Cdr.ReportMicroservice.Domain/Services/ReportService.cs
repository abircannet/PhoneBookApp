using Cdr.ReportMicroservice.Domain.DTOs;
using Cdr.ReportMicroservice.Domain.Entities;
using Cdr.ReportMicroservice.Domain.Interfaces;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Domain.Services
{
    public class ReportService : IReportService
    {
        IRepository<Report> _repository;
        private readonly IMessageService _messageService;

        public ReportService(IRepository<Report> repository,IMessageService messageService)
        {
            _repository = repository;
            this._messageService = messageService;
        }

        public void Create(SendReportRequestMessageDTO dto)
        { 
            _messageService.SendMessage(dto); 
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
