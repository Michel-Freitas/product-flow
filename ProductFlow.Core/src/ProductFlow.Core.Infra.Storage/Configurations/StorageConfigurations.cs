using ProductFlow.Core.Infra.Storage.Enums;

namespace ProductFlow.Core.Infra.Storage.Configurations
{
    public class StorageConfigurations
    {
        public string Endpoint { get; set; }
        public int Port { get; set; }
        public string AcessKey { get; set; }
        public string SecretKey { get; set; }
        public bool UseSSL { get; set; }
        public Dictionary<string, string> Buckets { get; set; }

        public Dictionary<BucketsEnum, string> BucketNames =>
            Buckets.ToDictionary(
                b => Enum.Parse<BucketsEnum>(b.Key, ignoreCase: true),
                b => b.Value
            );
    }
}
