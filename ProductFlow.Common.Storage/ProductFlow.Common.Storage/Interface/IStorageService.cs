using ProductFlow.Common.Storage.Enums;

namespace ProductFlow.Common.Storage.Interface
{
    public interface IStorageService
    {
        Task UploadFile(BucketsEnum bucket, string key, Stream file, string contentType);
        Task<string> DownloadFile(BucketsEnum bucket, string key);
        Task DeleteFile(BucketsEnum bucket, string key);
        string GetBucket(BucketsEnum bucket);
    }
}
