using ProductFlow.FileCron.Domain.Enums;

namespace ProductFlow.FileCron.Domain.Entity
{
    public class FileEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public long SizeByte { get; set; }
        public int TotalRows { get; set; }
        public string Path { get; set; }
        public FileExtensionEnum Extension { get; set; }
        public FileStatusEnum Status { get; set; }
        public int UserId { get; set; }
    }
}
