using ProductFlow.FileCron.Infraestructure.Db.Context;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Interface;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Service;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Settings;
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

            services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBroker"));
            services.AddSingleton<IMessageBrokerService, MessageBrokerService>();
            services.AddSingleton<IProcessFileService, ProcessFileService>();
        }
    }
}
