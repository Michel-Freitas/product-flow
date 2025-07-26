using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using ProductFlow.Common.Storage.Configurations;
using ProductFlow.Common.Storage.Enums;
using ProductFlow.Common.Storage.Interface;

namespace ProductFlow.Common.Storage.Service
{
    public class StorageService(
            IMinioClient client,
            IOptions<StorageConfigurations> storageConfig
        ) : IStorageService
    {
        private readonly Dictionary<BucketsEnum, string> _buckets = storageConfig.Value.BucketNames;
        private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), storageConfig.Value.PathDownload ?? "files_temp");

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

            throw new BucketNotFoundException($"Bucket {bucket} not configured.");
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

        public async Task<string> DownloadFile(BucketsEnum bucket, string key)
        {
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            var bucketName = GetBucket(bucket);
            var filePath = Path.Combine(_basePath, key);

            GetObjectArgs args = new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(key)
                .WithFile(filePath);

            await client.GetObjectAsync(args);

            return filePath;
        }
    }
}
