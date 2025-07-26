using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFlow.Common.MessageBroker.Configurations;
using ProductFlow.Common.MessageBroker.Factory;
using ProductFlow.Common.MessageBroker.Interface;
using ProductFlow.Common.MessageBroker.Service;

namespace ProductFlow.Common.MessageBroker.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessageBrokerConfigurations>(configuration.GetSection("MessageBroker"));
            services.AddSingleton<IConsumerFactory, ConsumerFactory>();
            services.AddSingleton<IProducerFactory, ProducerFactory>();
            services.AddSingleton<IMessageBrokerService, MessageBrokerService>();
        }
    }
}
