using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
namespace WebApplication4.src.Application.Subject.Command
{
    public class DeleteSubjectCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

    }
}
