using Confluent.Kafka;
using Microsoft.Extensions.Options;
using ProductFlow.Common.MessageBroker.Configurations;
using ProductFlow.Common.MessageBroker.Interface;

namespace ProductFlow.Common.MessageBroker.Factory
{
    internal class ConsumerFactory(IOptions<MessageBrokerConfigurations> options) : IConsumerFactory
    {
        private readonly MessageBrokerConfigurations _config = options.Value;

        public IConsumer<Ignore, string> Create()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _config.Endpoint,
                GroupId = _config.Consumer.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = _config.Consumer.EnableAutoCommit
            };

            return new ConsumerBuilder<Ignore, string>(config).Build();
        }
    }
}
