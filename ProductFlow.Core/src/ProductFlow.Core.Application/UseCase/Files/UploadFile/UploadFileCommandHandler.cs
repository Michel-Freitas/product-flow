using MediatR;
using ProductFlow.Core.Application.Model;
using ProductFlow.Core.Domain.Entity;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Domain.Interfaces.Service;
using ProductFlow.Core.Infra.Storage.Interface;

namespace ProductFlow.Core.Application.UseCase.Files.UploadFile
{
    public class UploadFileCommandHandler(
        IUnitOfWork unitOfWork,
        IStorageService storageService,
        IUserService userService,
        IFileService fileService
    ) : IRequestHandler<UploadFileCommand, DefaulResult>
    {
        public async Task<DefaulResult> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementação
            // [x] - Verificar se o usuário já existe:
            // - Caso sim: Pegar seu Id
            // - Caso não: Criar e pegar seu Id
            // [ ] - Pegar as informações do arquivo e salvar no banco de dados
                // - Filename, Size in Byte, Total Rows, Path to Save, Extension, User Id
            // [ ] - Salvar o Arquivo no Bucket
            // [ ] - Notificar ao sistema de Processamento de Arquivo para começar o processamento desse arquivo
            // [ ] - Retornar sucesso informando que o arquivo vai ser processado

            await unitOfWork.BeginTransactionAsync();
            string path = fileService.GeneratePathFile(request.File.FileName);
            try
            {
                var user = await unitOfWork.UserRepository.GetByEmailAsync(request.Email);

                if (user == null) {
                    user = await userService.InsertAsync(new(name: request.Username, email: request.Email));
                    await unitOfWork.SaveChangesAsync();
                }                    

                var fileEntity = new FileEntity(
                    name: request.File.FileName,
                    extension: fileService.GetFileExtension(request.File.FileName),
                    sizeByte: request.File.Length,
                    path: path,
                    userId: user.Id
                );

                var result = await fileService.InsertAsync(fileEntity);

                await storageService.UploadFile(
                    bucket: Infra.Storage.Enums.BucketsEnum.ProductFlow,
                    key: fileEntity.Path,
                    file: request.File.OpenReadStream(),
                    contentType: request.File.ContentType
                );

                await unitOfWork.CommitAsync();
                return new DefaulResult($"Vamos Processar o arquivo {request.File.FileName}");
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                await storageService.DeleteFile(Infra.Storage.Enums.BucketsEnum.ProductFlow, path);
                throw;
            }
        }
    }
}
