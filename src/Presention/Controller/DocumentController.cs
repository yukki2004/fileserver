using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.Queries;
using WebApplication4.src.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication4.src.Presention.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddDocument/{subjectId}/{type}")]
        public async Task<IActionResult> AddDocument(Guid subjectId, string type, IFormFile file, CancellationToken cancellationToken)
        {
            var command = new AddDocumentCommand
            {
                SubjectId = subjectId,
                type = type,
                File = file
            };
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
        [HttpDelete("DeleteDocument/{Id}")]
        public async Task<IActionResult> DeleteDocument(Guid Id, CancellationToken cancellationToken)
        {
            var command = new DeleteDocumentCommand
            {
               Id = Id
            };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
