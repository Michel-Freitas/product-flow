using ProductFlow.Core.Infra.Storage.Enums;

namespace ProductFlow.Core.Infra.Storage.Interface
{
    public interface IStorageService
    {
        Task UploadFile(BucketsEnum bucket, string key, Stream file, string contentType);
        Task DeleteFile(BucketsEnum bucket, string key);
        string GetBucket(BucketsEnum bucket);
    }
}
