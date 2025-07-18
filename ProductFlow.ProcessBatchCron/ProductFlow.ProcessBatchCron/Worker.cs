using Microsoft.Extensions.Options;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Dto;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Interface;
using ProductFlow.ProcessBatchCron.Infraestructure.MessageBroker.Settings;
using ProductFlow.ProcessBatchCron.UseCase.ProcessBatch.Interface;

namespace ProductFlow.ProcessBatchCron
{
    public class Worker(
        ILogger<Worker> logger,
        IMessageBrokerService brokerService,
        IProcessBatchService processBatchService,
        IOptions<MessageBrokerSettings> options
    ) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            brokerService.Subscribe(options.Value.Consumer.TopicName);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var message = brokerService.Consume<EventDto<List<string>>>();
                    await processBatchService.ExecuteAsyn(message);
                    brokerService.Commit();
                }
                catch
                {
                    logger.LogError("Tivemos um problema.");
                }
            }
        }
    }
}
