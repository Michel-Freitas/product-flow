using ProductFlow.FileCron.Domain.Interface.Repository;
using ProductFlow.FileCron.Infraestructure.MessageBroker.Dto;
using ProductFlow.FileCron.Infraestructure.Storage.Enums;
using ProductFlow.FileCron.Infraestructure.Storage.Interface;
using ProductFlow.FileCron.UseCase.ProcessFile.Dto;
using ProductFlow.FileCron.UseCase.ProcessFile.Interface;

namespace ProductFlow.FileCron.UseCase.ProcessFile.Service
{
    public class ProcessFileService(
        IFileRepository fileRepository,
        IStorageService storageService
    ) : IProcessFileService
    {
        public async Task ExecuteAsyn(EventDto<FileUploadedEventDto> input)
        {
            var fileEntity = await fileRepository.GetFileById(input.Data.FileId);
            // TODO: [ ] - Implementar trava para caso a entidade não exista no banco de dados
            var filePath = await storageService.DownloadFile(BucketsEnum.ProductFlow, fileEntity.Path);
            // TODO: [ ] - Implementar fluxo de arquivo não encontrado
            // TODO: [ ] - Verificar se o arquivo já teve uma tentativa de processamento, caso sim deve continuar de onde parou
            // TODO: [ ] - Atualizar o Status do Arquivo para 'WAITING'

            using var reader = new StreamReader(filePath);
            var buffer = new List<string>();

            while(!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (line == null) continue;

                buffer.Add(line);

                if (buffer.Count == 500)
                {
                    // TODO: [ ] - Salvar no banco os dados do batch enviado para processamento futuro caso trave o processo
                    // TODO: [ ] - Enviar o batch para o Kafka
                    buffer.Clear();
                }
            }

            if (buffer.Count > 0)
            {
                // TODO: [ ] - Salvar no banco os dados do batch enviado para processamento futuro caso trave o processo
                // TODO: [ ] - Enviar o batch para o Kafka
                buffer.Clear();
            }

            // TODO: [ ] - Quando terminar o processamento deve ser avisado o Core API sobre o fim do processamento
        }
    }
}