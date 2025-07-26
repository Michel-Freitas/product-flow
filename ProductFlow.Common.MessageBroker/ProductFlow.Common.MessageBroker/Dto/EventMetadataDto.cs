namespace ProductFlow.Common.MessageBroker.Dto
{
    public class EventMetadataDto
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public string Source { get; set; } = System.Reflection.Assembly.GetEntryAssembly()?.GetName()?.Name ?? string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
