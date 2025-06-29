using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Domain.Interfaces.Repository
{
    public interface IFileRepository
    {
        Task<FileEntity> InsertAsync(FileEntity entity);
    }
}
