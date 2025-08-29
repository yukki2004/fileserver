using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
using WebApplication4.src.Domain.Interfaces;
using WebApplication4.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication4.src.Application.Subject.Command
{
    public class DeleteDocumentCommandHanlde : IRequestHandler<DeleteDocumentCommand, Unit>
    {
        private readonly IDocumentFileService _fileService;
        private readonly IDocumentResposity _documentResposity;
        private readonly ISubjectResposity _subjectResposity;
        public DeleteDocumentCommandHanlde(IDocumentFileService fileService, IDocumentResposity documentResposity, ISubjectResposity subjectResposity)
        {
            _fileService = fileService;
            _documentResposity = documentResposity;
            _subjectResposity = subjectResposity;
        }
        public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _documentResposity.GetDocumentById(request.Id);
            if (document != null)
            {
                var subject = await _subjectResposity.GetSubjectById(document.SubjectId);
                await _documentResposity.DeleteDocument(request.Id);
                await _fileService.DeleteDocumentFolder(subject.code, document.Type, document.FileName, cancellationToken);
            }
            return Unit.Value;
        }
    }
}
