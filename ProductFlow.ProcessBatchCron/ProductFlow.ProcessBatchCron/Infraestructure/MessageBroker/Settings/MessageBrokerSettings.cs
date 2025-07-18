namespace ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Settings
{
    public class MessageBrokerSettings
    {
        public string Endpoint { get; set; } = string.Empty;
        public ConsumerSettings Consumer { get; set; }
    }
}
