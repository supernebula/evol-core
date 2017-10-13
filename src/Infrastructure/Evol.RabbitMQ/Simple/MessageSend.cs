using System;
using RabbitMQ.Client;
using System.Text;

namespace Evol.RabbitMQ.Simple
{
    public class MessageSend : IDisposable
    {
        private static MessageSend _instance;

        public static MessageSend Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageSend();
                return _instance;
            }
        }

        private IConnection connection;

        public MessageSend()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }

        public void Send(string message = "Hello World!")
        {

            using (var channel = connection.CreateModel())
            {

                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            }

        }


    }
}
