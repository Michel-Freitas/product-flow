using ProductFlow.FileCron.Domain.Entity;
using ProductFlow.FileCron.Domain.Enums;

namespace ProductFlow.FileCron.Domain.Interface.Repository
{
    public interface IFileRepository
    {
        Task UpdateStatusAsync(int id, FileStatusEnum status);
        Task<FileEntity?> GetFileById(int id);
    }
}
