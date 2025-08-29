using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
namespace WebApplication4.src.Application.Subject.Command
{
    public class DeleteDocumentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        
    }
}
