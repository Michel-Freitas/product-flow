using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFlow.Core.Infra.MessageBroker.Interface;
using ProductFlow.Core.Infra.MessageBroker.Service;
using ProductFlow.Core.Infra.MessageBroker.Settings;

namespace ProductFlow.Core.Infra.MessageBroker.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBroker"));
            services.AddSingleton<IMessageBrokerService, MessageBrokerService>();
        }
    }
}
