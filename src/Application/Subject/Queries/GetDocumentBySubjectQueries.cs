using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
namespace WebApplication4.src.Application.Subject.Queries
{
    public class GetDocumentBySubjectQueries : IRequest<DTOs.DocumentDto>
    {
        public Guid SubjectId { get; set; }
        public string type { get; set; } = null!;
    }
}
