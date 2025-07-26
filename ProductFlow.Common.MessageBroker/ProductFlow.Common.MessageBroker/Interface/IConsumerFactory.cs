using Confluent.Kafka;

namespace ProductFlow.Common.MessageBroker.Interface
{
    public interface IConsumerFactory
    {
        IConsumer<Ignore, string> Create();
    }
}
