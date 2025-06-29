using System.Net;
using ProductFlow.Core.Domain.Exceptions;

namespace ProductFlow.Core.Application.Exceptions
{
    public class ApiException : BaseException
    {
        public List<string> Errors { get; set; }
        public ApiException(HttpStatusCode httpStatusCode, string message) : base(httpStatusCode, message) { }

        public ApiException(HttpStatusCode httpStatusCode, List<string> errors, string message = "")
            : base(httpStatusCode, message)
        {
            Errors = errors;
        }
    }
}
