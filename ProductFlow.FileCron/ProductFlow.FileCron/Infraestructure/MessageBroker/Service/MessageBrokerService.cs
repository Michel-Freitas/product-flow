using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Interface;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Settings;

namespace ProductFlow.FileCron.Infraestructure.MessageBroker.Service
{
    public class MessageBrokerService : IMessageBrokerService, IDisposable
    {
        private readonly IConsumer<Ignore, string> _consumer;

        public MessageBrokerService(IOptions<MessageBrokerSettings> options)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = options.Value.Endpoint,
                GroupId = options.Value.Consumer.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                // EnableAutoCommit = options.Value.Consumer.EnableAutoCommit
            };

            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }

        public T Consume<T>()
        {
            try
            {
                var consumerEvent = _consumer.Consume();
                var messageValue = JsonConvert.DeserializeObject<T>(consumerEvent.Message.Value);

                return messageValue == null ? throw new ArgumentException("Nenhuma mensagem para ser retornada") : messageValue;
            }
            catch
            {
                throw;
            }
        }

        public void Subscribe(string topic)
        {
            _consumer.Subscribe(topic);
        }

        public void Commit()
        {
            _consumer.Commit();
        }

        public void Dispose()
        {
            _consumer.Close();
            _consumer.Dispose();
        }
    }
}
