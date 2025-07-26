using Confluent.Kafka;

namespace ProductFlow.Common.MessageBroker.Interface
{
    public interface IProducerFactory
    {
        IProducer<Null, string> Create();
    }
}
