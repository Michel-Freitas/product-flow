using ProductFlow.FileCron.Infraestructure.MessageBroker.Dto;
using ProductFlow.FileCron.UseCase.ProcessFile.Dto;

namespace ProductFlow.FileCron.UseCase.ProcessFile.Interface
{
    public interface IProcessFileService
    {
        Task ExecuteAsyn(EventDto<FileUploadedEventDto> input);
    }
}
