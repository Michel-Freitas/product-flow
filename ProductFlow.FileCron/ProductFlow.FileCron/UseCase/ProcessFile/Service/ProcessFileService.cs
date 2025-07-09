using ProductFlow.FileCron.Infraestructure.MessageBroker.Dto;
using ProductFlow.FileCron.UseCase.ProcessFile.Dto;
using ProductFlow.FileCron.UseCase.ProcessFile.Interface;

namespace ProductFlow.FileCron.UseCase.ProcessFile.Service
{
    public class ProcessFileService : IProcessFileService
    {
        public async Task ExecuteAsyn(EventDto<FileUploadedEventDto> input)
        {
            Console.WriteLine($"*** [DEBUG] FiedId: {input.Data.FileId} ***");
            Console.WriteLine($"*** [DEBUG] Source: {input.Metadata.Source} ***");
        }
    }
}
// [x] - Consumir Topico de processamento do arquivo
// [ ] - Buscar o path do arquivo e validar se o registro existe no banco de dados
// [ ] - Buscar o arquivo na Storage
// [ ] - Atualizar o Status do Arquivo para 'WAITING'
// [ ] - Começar a leitura do arquivo em batch de 500 registro
// [ ] - Para cada batch deve ser feito o envio da lista de linhas para o Kafka
// [ ] - Para cada batch deve ser atualizado a tabela de acompanahento de integração, registrando até qual batch foi enviado
// [ ] - Quando terminar o processamento deve ser avisado o Core API sobre o fim do processamento
// [ ] - Caso o arquivo falhe, precisamos reprocessar ele e continuar de onde parou