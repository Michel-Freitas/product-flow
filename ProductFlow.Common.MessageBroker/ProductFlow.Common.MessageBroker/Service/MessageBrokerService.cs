using Confluent.Kafka;
using Newtonsoft.Json;
using ProductFlow.Common.MessageBroker.Dto;
using ProductFlow.Common.MessageBroker.Interface;

namespace ProductFlow.Common.MessageBroker.Service
{
    public class MessageBrokerService(
        IProducerFactory producerFactory,
        IConsumerFactory consumerFactory
    ) : IMessageBrokerService, IDisposable
    {
        private readonly IConsumer<Ignore, string> _consumer = consumerFactory.Create();
        private readonly IProducer<Null, string> _producer = producerFactory.Create();
        public T Consume<T>()
        {
            try
            {
                var consumerEvent = _consumer.Consume();
                var messageValue = JsonConvert.DeserializeObject<T>(consumerEvent.Message.Value);

                return messageValue == null ? throw new ArgumentException("No message to be returned") : messageValue;
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

        public async Task PublishAsync<T>(string topic, T message)
        {
            var jsonMessage = JsonConvert.SerializeObject(new EventDto<T>(message));

            var sendMessage = new Message<Null, string>
            {
                Value = jsonMessage
            };

            await _producer.ProduceAsync(topic, sendMessage);
        }
    }
}
