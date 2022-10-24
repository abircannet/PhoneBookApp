using Cdr.ReportMicroservice.Domain.Constants;
using Cdr.ReportMicroservice.Domain.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace Cdr.ReportMicroservice.Infrastructure.MessageServices
{
    public class RabbitMQMessageProducer : IMessageService
    {

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(MessageServiceConst.ReportQueueName, true, false, false, null);
            channel.QueueBind(
                queue: MessageServiceConst.ReportQueueName,
                exchange: MessageServiceConst.ReportExchangeName,
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
