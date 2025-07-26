using ProductFlow.Common.MessageBroker.DI;
using ProductFlow.Common.Storage.DI;
using ProductFlow.FileCron.Domain.Interface.Repository;
using ProductFlow.FileCron.Infraestructure.Db.Context;
using ProductFlow.FileCron.Infraestructure.Db.Repository;
using ProductFlow.FileCron.UseCase.ProcessFile.Interface;
using ProductFlow.FileCron.UseCase.ProcessFile.Service;

namespace ProductFlow.FileCron.Infraestructure.DI
{
    public static class DependencyInjection
    {
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton<ICronDbContext>(new CronDbContext(connectionString!));

            services.AddDependencyMessageBroker(configuration);
            services.AddDependencyStorage(configuration);
            services.AddSingleton<IFileRepository, FileRepository>();
            services.AddSingleton<IProcessFileService, ProcessFileService>();
        }
    }
}
