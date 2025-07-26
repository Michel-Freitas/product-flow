using Microsoft.Extensions.Options;
using ProductFlow.Common.MessageBroker.Configurations;
using ProductFlow.Common.MessageBroker.Dto;
using ProductFlow.Common.MessageBroker.Interface;
using ProductFlow.FileCron.UseCase.ProcessFile.Dto;
using ProductFlow.FileCron.UseCase.ProcessFile.Interface;

namespace ProductFlow.FileCron
{
    public class Worker(
        ILogger<Worker> logger,
        IMessageBrokerService brokerService,
        IProcessFileService processFileService,
        IOptions<MessageBrokerConfigurations> options
    ) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"***** Starting Reading the Topic {options.Value.Consumer.TopicName} *****");
            brokerService.Subscribe(options.Value.Consumer.TopicName);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var message = brokerService.Consume<EventDto<FileUploadedEventDto>>();
                    await processFileService.ExecuteAsyn(message);
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