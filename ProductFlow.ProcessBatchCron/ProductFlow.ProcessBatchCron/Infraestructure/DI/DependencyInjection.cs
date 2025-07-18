using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Interface;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Service;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Settings;
using ProductFlow.ProcessBatchCron.UseCase.ProcessBatch.Interface;
using ProductFlow.ProcessBatchCron.UseCase.ProcessBatch.Service;

namespace ProductFlow.ProcessBatchCron.Infraestructure.DI
{
    public static class DependencyInjection
    {
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBroker"));
            services.AddSingleton<IMessageBrokerService, MessageBrokerService>();
            services.AddSingleton<IProcessBatchService, ProcessBatchService>();
        }
    }
}
