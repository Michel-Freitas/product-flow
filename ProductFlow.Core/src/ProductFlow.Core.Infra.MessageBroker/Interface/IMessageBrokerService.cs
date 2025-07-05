namespace ProductFlow.Core.Infra.MessageBroker.Interface
{
    public interface IMessageBrokerService
    {
        Task PublishAsync<T>(string topic, T message);
    }
}
