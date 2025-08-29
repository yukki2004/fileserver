using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
namespace WebApplication4.src.Application.Subject.Command
{
    public class AddDocumentCommand :IRequest<DocumentDto>
    {
        public Guid SubjectId { get; set; }
        public string type { get; set; } = null!;
        public IFormFile File { get; set; } = default!;

    }
}
