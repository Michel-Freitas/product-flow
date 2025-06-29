using ProductFlow.Core.Domain.Entity;
using ProductFlow.Core.Domain.Enums;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Domain.Interfaces.Service;

namespace ProductFlow.Core.Domain.Service.Service
{
    public class FileService(IUnitOfWork unitOfWork) : IFileService
    {
        private readonly IFileRepository _repository = unitOfWork.FileRepository;
        public string GeneratePathFile(string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{name}_{dateTime}.{extension}";
        }

        public FileExtensionEnum GetFileExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Nome do arquivo inválido.", nameof(fileName));

            var extension = Path.GetExtension(fileName)?.TrimStart('.').ToUpperInvariant();

            if (string.IsNullOrEmpty(extension))
                throw new InvalidOperationException("Extensão do arquivo não encontrada.");

            if (Enum.TryParse<FileExtensionEnum>(extension, ignoreCase: true, out var enumValue) &&
                Enum.IsDefined(typeof(FileExtensionEnum), enumValue))
            {
                return enumValue;
            }

            throw new NotSupportedException($"Extensão de arquivo '{extension}' não suportada.");
        }

        public async Task<FileEntity> InsertAsync(FileEntity entity)
        {
            return (await _repository.InsertAsync(entity));
        }
    }
}
