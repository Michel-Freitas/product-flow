namespace ProductFlow.Common.MessageBroker.Configurations
{
    public class ConsumerConfigurations
    {
        public string GroupId { get; set; } = string.Empty;
        public string TopicName { get; set; } = string.Empty;
        public bool EnableAutoCommit { get; set; } = false;
    }
}
