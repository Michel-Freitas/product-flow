using MediatR;
using ProductFlow.Core.Application.EventsBroker.Dto;
using ProductFlow.Core.Application.EventsBroker.Topics;
using ProductFlow.Core.Application.Model;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Domain.Interfaces.Service;
using ProductFlow.Core.Infra.MessageBroker.Interface;
using ProductFlow.Core.Infra.Storage.Interface;

namespace ProductFlow.Core.Application.UseCase.Files.UploadFile
{
    public class UploadFileCommandHandler(
        IUnitOfWork unitOfWork,
        IStorageService storageService,
        IUserService userService,
        IFileService fileService,
        IMessageBrokerService brokerService
    ) : IRequestHandler<UploadFileCommand, DefaulResult>
    {
        public async Task<DefaulResult> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            string path = fileService.GeneratePathFile(request.File.FileName);
            try
            {
                var user = await unitOfWork.UserRepository.GetByEmailAsync(request.Email);

                if (user == null)
                {
                    user = new(name: request.Username, email: request.Email);
                    await userService.InsertAsync(user);
                }

                var fileEntity = await fileService.InsertAsync(new(
                    name: request.File.FileName,
                    extension: fileService.GetFileExtension(request.File.FileName),
                    sizeByte: request.File.Length,
                    path: path,
                    userId: user.Id
                ));
                fileEntity.User = user;

                await storageService.UploadFile(
                    bucket: Infra.Storage.Enums.BucketsEnum.ProductFlow,
                    key: fileEntity.Path,
                    file: request.File.OpenReadStream(),
                    contentType: request.File.ContentType
                );

                await unitOfWork.CommitAsync();
                await brokerService.PublishAsync<FileUploadedEventDto>(EventsBrokerTopic.FileUploaded, new(fileEntity.Id));

                return new DefaulResult($"Vamos Processar o arquivo {request.File.FileName}");
            }
            catch
            {
                await storageService.DeleteFile(Infra.Storage.Enums.BucketsEnum.ProductFlow, path);
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
