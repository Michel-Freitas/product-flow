namespace ProductFlow.Core.Domain.Entity
{
    public class UserEntity(string name, string email) : BaseEntity
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public ICollection<FileEntity> Files { get; set; } = [];
    }
}
