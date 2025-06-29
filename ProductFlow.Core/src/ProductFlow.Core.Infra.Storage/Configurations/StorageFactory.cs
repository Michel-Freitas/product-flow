using Minio;

namespace ProductFlow.Core.Infra.Storage.Configurations
{
    public class StorageFactory(StorageConfigurations storageConfig)
    {
        public IMinioClient Create()
        {
            return new MinioClient()
                .WithEndpoint(storageConfig.Endpoint, storageConfig.Port)
                .WithCredentials(storageConfig.AcessKey, storageConfig.SecretKey)
                .WithSSL(storageConfig.UseSSL)
                .Build();
        }
    }
}
