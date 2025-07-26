namespace ProductFlow.Common.MessageBroker.Interface
{
    public interface IMessageBrokerService
    {
        Task PublishAsync<T>(string topic, T message);
        T Consume<T>();
        void Subscribe(string topic);
        void Commit();
    }
}
