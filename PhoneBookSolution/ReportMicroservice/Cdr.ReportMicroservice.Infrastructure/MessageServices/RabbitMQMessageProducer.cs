using Cdr.ReportMicroservice.Domain.Constants;
using Cdr.ReportMicroservice.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Infrastructure.MessageServices
{
    public class RabbitMQMessageProducer : IMessageService
    {
        private readonly IConfiguration configuration;

        public RabbitMQMessageProducer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = configuration.GetSection("RabbitMQService").Value };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(MessageServiceConst.ReportQueueName, true, false, false, null);
            channel.QueueBind(
                exchange: MessageServiceConst.ReportExchangeName,
                queue: MessageServiceConst.ReportQueueName,
                routingKey: MessageServiceConst.ReportRouting);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            var json = System.Text.Json.JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(
                exchange: MessageServiceConst.ReportExchangeName, 
                routingKey: MessageServiceConst.ReportRouting,
                basicProperties: properties,
                body: body);

        }
    }
}
