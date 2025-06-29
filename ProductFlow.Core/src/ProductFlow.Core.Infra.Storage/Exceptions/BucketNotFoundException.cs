namespace ProductFlow.Core.Infra.Storage.Exceptions
{
    public class BucketNotFoundException(string message) : Exception(message){ }
}
