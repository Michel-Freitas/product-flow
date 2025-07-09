namespace ProductFlow.FileCron.Infraestructure.MessageBroker.Settings
{
    public class ConsumerSettings
    {
        public string GroupId { get; set; } = string.Empty;
        public string TopicName {  get; set; } = string.Empty;
        public bool EnableAutoCommit { get; set; } = false;
    }
}
