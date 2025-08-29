using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.Queries;
using WebApplication4.src.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication4.src.Presention.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] AddSubjectCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteSubjectCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
