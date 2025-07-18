namespace ProductFlow.FileCron.Infraestructure.MessageBroker.Interface
{
    public interface IMessageBrokerService
    {
        T Consume<T>();
        void Subscribe(string topic);
        void Commit();
        Task PublishAsync<T>(string topic, T message);
    }
}
