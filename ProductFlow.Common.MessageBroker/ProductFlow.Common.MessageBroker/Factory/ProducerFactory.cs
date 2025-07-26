using Confluent.Kafka;
using Microsoft.Extensions.Options;
using ProductFlow.Common.MessageBroker.Configurations;
using ProductFlow.Common.MessageBroker.Interface;

namespace ProductFlow.Common.MessageBroker.Factory
{
    public class ProducerFactory(IOptions<MessageBrokerConfigurations> options) : IProducerFactory
    {
        public IProducer<Null, string> Create()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = options.Value.Endpoint
            };

            return new ProducerBuilder<Null, string>(config).Build();
        }
    }
}
