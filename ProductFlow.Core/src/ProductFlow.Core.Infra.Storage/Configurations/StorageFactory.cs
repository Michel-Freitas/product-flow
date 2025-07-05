using Microsoft.Extensions.Options;
using Minio;

namespace ProductFlow.Core.Infra.Storage.Configurations
{
    public class StorageFactory(IOptions<StorageConfigurations> storageConfig)
    {
        private readonly StorageConfigurations _config = storageConfig.Value;

        public IMinioClient Create()
        {
            return new MinioClient()
                .WithEndpoint(_config.Endpoint, _config.Port)
                .WithCredentials(_config.AcessKey, _config.SecretKey)
                .WithSSL(_config.UseSSL)
                .Build();
        }
    }
}
