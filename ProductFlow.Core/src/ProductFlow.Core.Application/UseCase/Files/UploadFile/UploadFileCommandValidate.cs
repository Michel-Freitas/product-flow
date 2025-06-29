using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProductFlow.Core.Application.UseCase.Files.UploadFile
{
    public class UploadFileCommandValidate : AbstractValidator<UploadFileCommand>
    {
        private readonly string[] permittedExtensions = { ".csv" };

        public UploadFileCommandValidate()
        {
            RuleFor(p => p.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .WithMessage("Campo 'Username' precisa ter no mínimo 3 caracteres.");

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Campo 'Email' está incorreto.");

            RuleFor(p => p.File)
                .NotNull().WithMessage("Campo 'File' é obrigatório.")
                .Must(file => file.Length > 0).WithMessage("Campo 'File' está vázio.")
                .Must(file => HasValidExtension(file))
                .WithMessage("Campo 'File' só é permitido arquivos: 'CSV'");
        }

        private bool HasValidExtension(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            return !string.IsNullOrWhiteSpace(extension) && permittedExtensions.Contains(extension);
        }
    }
}
