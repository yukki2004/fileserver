using MediatR;
using WebApplication4.src.Application.Subject.Command;
namespace WebApplication4.src.Application.Subject.Command
{
    public class AddSubjectCommand : IRequest<DTOs.SubjectDto>
    {
        public string name { get; set; } = null!;
        public string code { get; set; } = null!;
    }
}
