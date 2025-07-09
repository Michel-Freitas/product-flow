namespace ProductFlow.FileCron.Infraestructure.MessageBroker.Interface
{
    public interface IMessageBrokerService
    {
        T Consume<T>();
        void Subscribe(string topic);
        void Commit();
    }
}
