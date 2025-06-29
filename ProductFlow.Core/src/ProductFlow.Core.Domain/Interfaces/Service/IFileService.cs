using ProductFlow.Core.Domain.Entity;
using ProductFlow.Core.Domain.Enums;

namespace ProductFlow.Core.Domain.Interfaces.Service
{
    public interface IFileService
    {
        Task<FileEntity> InsertAsync(FileEntity entity);
        string GeneratePathFile(string fileName);
        FileExtensionEnum GetFileExtension(string fileName);
    }
}
