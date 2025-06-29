using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductFlow.Core.Application.UseCase.Files.UploadFile;

namespace ProductFlow.Core.Infra.Api.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileController(IMediator mediator) : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileCommand command)
        {
            command.IsValid();
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
