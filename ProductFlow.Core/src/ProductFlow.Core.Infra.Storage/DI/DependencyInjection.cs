using ProductFlow.Core.Infra.Storage.Interface;
using ProductFlow.Core.Infra.Storage.Service;
using ProductFlow.Core.Infra.Storage.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Minio;

namespace ProductFlow.Core.Infra.Storage.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StorageConfigurations>(configuration.GetSection("Storage"));
            services.AddSingleton<StorageFactory>();
            services.AddSingleton<IMinioClient>(options => options.GetRequiredService<StorageFactory>().Create());

            services.AddScoped<IStorageService, StorageService>();
        }
    }
}
