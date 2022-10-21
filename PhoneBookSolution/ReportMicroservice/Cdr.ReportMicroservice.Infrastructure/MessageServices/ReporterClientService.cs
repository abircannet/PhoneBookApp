using Cdr.ReportMicroservice.Domain.Constants;
using Cdr.ReportMicroservice.Domain.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Infrastructure.MessageServices
{
    public class ReporterClientService : IReporterClientService<IModel>
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public ReporterClientService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            if (_channel is { IsOpen: true })
                return _channel;

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(MessageServiceConst.ReportExchangeName, type: MessageServiceConst.ReportExchangeType, true, false);
            _channel.QueueDeclare(MessageServiceConst.ReportQueueName, true, false, false, null);
            _channel.QueueBind(
                exchange: MessageServiceConst.ReportExchangeName,
                queue: MessageServiceConst.ReportQueueName,
                routingKey: MessageServiceConst.ReportRouting);
            return _channel;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose(); 
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
