using ProductFlow.FileCron.Infraestructure.Storage.Configurations;
using ProductFlow.FileCron.Infraestructure.Storage.Interface;
using ProductFlow.FileCron.Infraestructure.Storage.Service;

namespace ProductFlow.FileCron.Infraestructure.Storage.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StorageConfigurations>(configuration.GetSection("Storage"));
            services.AddSingleton<StorageFactory>();
            services.AddSingleton(options => options.GetRequiredService<StorageFactory>().Create());

            services.AddSingleton<IStorageService, StorageService>();
        }
    }
}
