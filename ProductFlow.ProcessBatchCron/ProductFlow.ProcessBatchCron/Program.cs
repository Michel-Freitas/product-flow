using ProductFlow.ProcessBatchCron;
using ProductFlow.ProcessBatchCron.Infraestructure.DI;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDependency(builder.Configuration);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
