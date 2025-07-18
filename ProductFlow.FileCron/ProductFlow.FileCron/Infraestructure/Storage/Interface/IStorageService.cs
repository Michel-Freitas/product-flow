using ProductFlow.FileCron.Infraestructure.Storage.Enums;

namespace ProductFlow.FileCron.Infraestructure.Storage.Interface
{
    public interface IStorageService
    {
        Task<string> DownloadFile(BucketsEnum bucket, string key);
        string GetBucket(BucketsEnum bucket);
    }
}
