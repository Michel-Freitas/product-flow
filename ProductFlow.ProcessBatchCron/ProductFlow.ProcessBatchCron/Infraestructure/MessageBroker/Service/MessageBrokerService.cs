using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Interface;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Settings;

namespace ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Service
{
    public class MessageBrokerService(IOptions<MessageBrokerSettings> options) : IMessageBrokerService, IDisposable
    {
        private readonly IConsumer<Ignore, string> _consumer = CreateConsumer(options);

        private static IConsumer<Ignore, string> CreateConsumer(IOptions<MessageBrokerSettings> options)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = options.Value.Endpoint,
                GroupId = options.Value.Consumer.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = options.Value.Consumer.EnableAutoCommit
            };

            return new ConsumerBuilder<Ignore, string>(config).Build();
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
