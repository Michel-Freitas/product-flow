using System.Data;

namespace ProductFlow.FileCron.Infraestructure.Db.Context
{
    public interface ICronDbContext
    {
        IDbConnection CreateConnection();
    }
}
