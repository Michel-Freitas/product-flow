using ProductFlow.FileCron.Domain.Entity;
using ProductFlow.FileCron.Domain.Enums;
using ProductFlow.FileCron.Domain.Interface.Repository;
using ProductFlow.FileCron.Infraestructure.Db.Context;

namespace ProductFlow.FileCron.Infraestructure.Db.Repository
{
    public class FileRepository(ICronDbContext cronDbContext) : IFileRepository
    {
        public Task<FileEntity> GetFileById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusAsync(int id, FileStatusEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
