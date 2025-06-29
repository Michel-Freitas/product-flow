using Microsoft.EntityFrameworkCore;
using ProductFlow.Core.Domain.Entity;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Infra.Dao.Context;

namespace ProductFlow.Core.Infra.Dao.Repository
{
    public class FileRepository(AppDbContext appDbContext) : IFileRepository
    {
        private readonly DbSet<FileEntity> _file = appDbContext.File;
        public async Task<FileEntity> InsertAsync(FileEntity entity)
        {
            return (await _file.AddAsync(entity)).Entity;
        }
    }
}
