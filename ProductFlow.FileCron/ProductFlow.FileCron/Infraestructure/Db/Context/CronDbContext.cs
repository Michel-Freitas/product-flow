using System.Data;
using Npgsql;

namespace ProductFlow.FileCron.Infraestructure.Db.Context
{
    public class CronDbContext(string connectionString) : ICronDbContext
    {
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
