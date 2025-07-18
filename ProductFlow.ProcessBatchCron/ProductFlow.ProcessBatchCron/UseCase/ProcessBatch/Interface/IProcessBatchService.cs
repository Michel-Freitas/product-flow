using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Dto;

namespace ProductFlow.ProcessBatchCron.UseCase.ProcessBatch.Interface
{
    public interface IProcessBatchService
    {
        Task ExecuteAsyn(EventDto<List<string>> input);
    }
}
