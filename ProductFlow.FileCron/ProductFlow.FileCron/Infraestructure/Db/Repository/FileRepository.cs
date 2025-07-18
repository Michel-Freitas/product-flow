using Dapper;
using ProductFlow.FileCron.Domain.Entity;
using ProductFlow.FileCron.Domain.Enums;
using ProductFlow.FileCron.Domain.Interface.Repository;
using ProductFlow.FileCron.Infraestructure.Db.Context;

namespace ProductFlow.FileCron.Infraestructure.Db.Repository
{
    public class FileRepository(ICronDbContext cronDbContext) : IFileRepository
    {
        public async Task<FileEntity?> GetFileById(int id)
        {
            var sql = "SELECT \r\n" +
                    "id as Id, \r\n" +
                    "name as Name, \r\n" +
                    "size_byte as SizeByte, \r\n" +
                    "total_row as TotalRows, \r\n" +
                    "path as Path, \r\n" +
                    "extension as Extension, \r\n" +
                    "status as Status, \r\n" +
                    "user_id as UserId, \r\n" +
                    "created_at as CreatedAt \r\n" +
                "FROM tb_file \r\n" +
                "WHERE id = @id";
            using var connection = cronDbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<FileEntity>(sql, new { Id = id });
        }

        public Task UpdateStatusAsync(int id, FileStatusEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
