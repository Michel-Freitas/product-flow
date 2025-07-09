namespace ProductFlow.FileCron.Infraestructure.MessageBroker.Dto
{
    public class EventMetadataDto
    {
        public Guid EventId { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
