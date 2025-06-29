using ProductFlow.Core.Domain.Enums;

namespace ProductFlow.Core.Domain.Entity
{
    public class FileEntity(
        string name,
        long sizeByte,
        string path,
        FileExtensionEnum extension,
        int userId
    ) : BaseEntity
    {
        public string Name { get; set; } = name;
        public long SizeByte { get; set; } = sizeByte;
        public int TotalRows { get; set; } = 0;
        public string Path { get; set; } = path;
        public FileExtensionEnum Extension { get; set; } = extension;
        public FileStatusEnum Status { get; set; } = FileStatusEnum.PENDING;
        public int UserId { get; set; } = userId;
        public UserEntity User { get; set; }
    }
}
