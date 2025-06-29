using System.Net;

namespace ProductFlow.Core.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public BaseException(string message) : base(message) { }
        public BaseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
