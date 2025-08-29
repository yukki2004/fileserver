using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
using WebApplication4.src.Domain.Interfaces;
using WebApplication4.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication4.src.Application.Subject.Command
{
    public class DeleteSubjectCommandHandle : IRequestHandler<DeleteSubjectCommand, Unit>
    {
        private readonly IFileService _fileService;
        private readonly ISubjectResposity _subjectResposity;
        public DeleteSubjectCommandHandle(IFileService fileService, ISubjectResposity subjectResposity)
        {
            _fileService = fileService;
            _subjectResposity = subjectResposity;
        }
        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _subjectResposity.GetSubjectById(request.Id);
            if (subject != null)
            {
                await _subjectResposity.DeleteSubject(request.Id);
                await _fileService.DeleteSubjectFolder(subject.code, cancellationToken);
            }
            return Unit.Value;
        }
    }
}
