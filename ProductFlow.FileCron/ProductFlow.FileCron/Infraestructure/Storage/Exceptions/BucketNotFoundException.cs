namespace ProductFlow.FileCron.Infraestructure.Storage.Exceptions
{
    public class BucketNotFoundException(string message) : Exception(message){ }
}
