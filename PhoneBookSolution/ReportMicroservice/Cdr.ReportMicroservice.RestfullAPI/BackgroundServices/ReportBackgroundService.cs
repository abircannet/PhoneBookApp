using Cdr.ReportMicroservice.Domain.Interfaces;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Cdr.ReportMicroservice.Domain.Constants;
using Cdr.ReportMicroservice.Domain.DTOs;

namespace Cdr.ReportMicroservice.RestfullAPI.BackgroundServices
{
    public class ReportBackgroundService : BackgroundService
    {

        private readonly IReporterClientService<IModel> _reporterClientService;
        private readonly IExcelReportService _excelReportService;
        private readonly IReportApiService _reportApiService;
        private IModel _channel;

        public ReportBackgroundService(IReporterClientService<IModel> reporterClientService, IExcelReportService excelReportService, IReportApiService reportApiService)
        {

            _reporterClientService = reporterClientService;
            _excelReportService = excelReportService;
            _reportApiService = reportApiService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _reporterClientService.Connect();
            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(MessageServiceConst.ReportQueueName, false, consumer);
            consumer.Received += Consumer_Received; ;

            return Task.CompletedTask;
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        { 
            try
            {
                var dto = JsonSerializer.Deserialize<SendReportRequestMessageDTO>(Encoding.UTF8.GetString(@event.Body.ToArray()));
             
                var reportFile = await _excelReportService.CreateExcelAsync(dto);
               // await _reportApiService.CompleteReportAsync(reportFile, reportExcelMessageDto.ReportId);
                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception ex)
            { 
            }
        }
    }
}
