using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Dto;
using ProductFlow.ProcessBatchCron.UseCase.ProcessBatch.Interface;

namespace ProductFlow.ProcessBatchCron.UseCase.ProcessBatch.Service
{
    public class ProcessBatchService : IProcessBatchService
    {
        public Task ExecuteAsyn(EventDto<List<string>> input)
        {
            input.Data.ForEach(item => Console.WriteLine(item));
            return Task.CompletedTask;
        }
    }
}
