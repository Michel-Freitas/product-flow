namespace ProductFlow.Common.MessageBroker.Dto
{
    public class EventDto<T>(T data)
    {
        public EventMetadataDto Metadata { get; set; } = new();
        public T Data { get; set; } = data;
    }
}
