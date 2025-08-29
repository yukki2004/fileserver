using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
namespace WebApplication4.src.Application.Subject.Command
{
    public class UpdateSubjectCommand :IRequest<DTOs.SubjectDto>
    {
        public Guid Id { get; set; }
        public string name { get; set; } = null!;
        public string code { get; set; } = null!;

    }
}
