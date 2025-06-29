using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductFlow.Core.Application.Exceptions;
using ProductFlow.Core.Application.Model;

namespace ProductFlow.Core.Application.UseCase.Files.UploadFile
{
    public class UploadFileCommand : IRequest<DefaulResult>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public IFormFile File { get; set; }

        public UploadFileCommand() { }

        public UploadFileCommand(string username, string email, IFormFile file)
        {
            Username = username;
            Email = email;
            File = file;

            IsValid();
        }

        public void IsValid()
        {
            var validationResult = new UploadFileCommandValidate().Validate(this);

            if (validationResult.IsValid is false)
                throw new ApiException(HttpStatusCode.BadRequest, [.. validationResult.Errors.Select(e => e.ErrorMessage)]);
        }
    }
}
