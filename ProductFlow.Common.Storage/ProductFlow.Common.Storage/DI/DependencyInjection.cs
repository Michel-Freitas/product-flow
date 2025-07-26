using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFlow.Common.Storage.Configurations;
using ProductFlow.Common.Storage.Interface;
using ProductFlow.Common.Storage.Service;
using Minio;

namespace ProductFlow.Common.Storage.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StorageConfigurations>(configuration.GetSection("Storage"));
            services.AddSingleton<StorageFactory>();
            services.AddSingleton<IMinioClient>(options => options.GetRequiredService<StorageFactory>().Create());
            services.AddSingleton<IStorageService, StorageService>();
        }
    }
}
