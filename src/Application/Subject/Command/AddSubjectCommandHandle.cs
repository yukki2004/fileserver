using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
using WebApplication4.src.Domain.Interfaces;
using WebApplication4.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication4.src.Application.Subject.Command
{
    public class AddSubjectCommandHandle : IRequestHandler<AddSubjectCommand, SubjectDto>
    {
        private readonly IFileService _fileService;
        private readonly ISubjectResposity _subjectResposity;
        public AddSubjectCommandHandle(IFileService fileService, ISubjectResposity subjectResposity)
        {
            _fileService = fileService;
            _subjectResposity = subjectResposity;
        }
        public async Task<SubjectDto> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = new Subjects
            {
                Id = Guid.NewGuid(),
                name = request.name,
                code = request.code
            };
            await _subjectResposity.AddSubject(subject);
            await _fileService.AddSubjectFolder(request.code, cancellationToken);
            return new SubjectDto
            {
                Id = subject.Id,
                name = subject.name,
                code = subject.code
            };

        }
    }
}
