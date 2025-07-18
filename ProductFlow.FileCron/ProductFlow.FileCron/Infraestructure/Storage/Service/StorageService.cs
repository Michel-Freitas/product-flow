using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using ProductFlow.FileCron.Infraestructure.Storage.Configurations;
using ProductFlow.FileCron.Infraestructure.Storage.Enums;
using ProductFlow.FileCron.Infraestructure.Storage.Interface;

namespace ProductFlow.FileCron.Infraestructure.Storage.Service
{
    public class StorageService(
        IMinioClient client,
        IOptions<StorageConfigurations> storageConfig
    ) : IStorageService
    {
        private readonly Dictionary<BucketsEnum, string> _buckets = storageConfig.Value.BucketNames;
        private readonly string basePath = Path.Combine(Directory.GetCurrentDirectory(), "files_temp");

        public async Task<string> DownloadFile(BucketsEnum bucket, string key)
        {
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            var bucketName = GetBucket(bucket);
            var filePath = Path.Combine(basePath, key);

            GetObjectArgs args = new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(key)
                .WithFile(filePath);

            await client.GetObjectAsync(args);

            return filePath;
        }

        public string GetBucket(BucketsEnum bucket)
        {
            if (_buckets.TryGetValue(bucket, out var name))
                return name;

            throw new BucketNotFoundException($"Bucket {bucket} não configurado.");
        }
    }
}
