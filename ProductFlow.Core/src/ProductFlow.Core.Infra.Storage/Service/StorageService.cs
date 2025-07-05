using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using ProductFlow.Core.Infra.Storage.Configurations;
using ProductFlow.Core.Infra.Storage.Enums;
using ProductFlow.Core.Infra.Storage.Interface;

namespace ProductFlow.Core.Infra.Storage.Service
{
    public class StorageService(
        IMinioClient client,
        IOptions<StorageConfigurations> storageConfig
    ) : IStorageService
    {
        private readonly Dictionary<BucketsEnum, string> _buckets = storageConfig.Value.BucketNames;

        public async Task DeleteFile(BucketsEnum bucket, string key)
        {
            var bucketName = GetBucket(bucket);

            RemoveObjectArgs args = new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(key);

            await client.RemoveObjectAsync(args);
        }

        public string GetBucket(BucketsEnum bucket)
        {
            if (_buckets.TryGetValue(bucket, out var name))
                return name;

            throw new BucketNotFoundException($"Bucket {bucket} não configurado.");
        }

        public async Task UploadFile(BucketsEnum bucket, string key, Stream file, string contentType)
        {

            var bucketName = GetBucket(bucket);

            PutObjectArgs args = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(key)
                .WithStreamData(file)
                .WithObjectSize(file.Length)
                .WithContentType(contentType);

            await client.PutObjectAsync(args);

        }
    }
}
