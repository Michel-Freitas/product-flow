using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductFlow.Core.Infra.MessageBroker.Dto;
using ProductFlow.Core.Infra.MessageBroker.Interface;
using ProductFlow.Core.Infra.MessageBroker.Settings;

namespace ProductFlow.Core.Infra.MessageBroker.Service
{
    public class MessageBrokerService : IMessageBrokerService
    {
        private readonly IProducer<Null, string> _producer;

        public MessageBrokerService(IOptions<MessageBrokerSettings> options)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = options.Value.Endpoint
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
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
