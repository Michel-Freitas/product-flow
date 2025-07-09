using Microsoft.Extensions.Options;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Dto;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Interface;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Settings;
using ProductFlow.FileCron.UseCase.ProcessFile.Dto;
using ProductFlow.FileCron.UseCase.ProcessFile.Interface;

namespace ProductFlow.FileCron
{
    public class Worker(
        ILogger<Worker> logger,
        IMessageBrokerService brokerService,
        IProcessFileService processFileService,
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
                    var message = brokerService.Consume<EventDto<FileUploadedEventDto>>();
                    await processFileService.ExecuteAsyn(message);
                }
                catch
                {
                    logger.LogError("Tivemos um problema.");
                }
            }
        }
    }
}