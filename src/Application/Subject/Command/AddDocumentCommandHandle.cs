using MediatR;
using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.DTOs;
using WebApplication4.src.Domain.Interfaces;
using WebApplication4.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication4.src.Application.Subject.Command
{
    public class AddDocumentCommandHandle : IRequestHandler<AddDocumentCommand, DocumentDto>
    {
        private readonly IDocumentFileService _fileService;
        private readonly IDocumentResposity _documentResposity;
        private readonly ISubjectResposity _subjectResposity;
        public AddDocumentCommandHandle(IDocumentFileService fileService, IDocumentResposity documentResposity, ISubjectResposity subjectResposity)
        {
            _fileService = fileService;
            _documentResposity = documentResposity;
            _subjectResposity = subjectResposity;
        }
        public async Task<DocumentDto> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {

            var subject = await _subjectResposity.GetSubjectById(request.SubjectId);

            var link = await _fileService.AddDocumentFolder(subject.code, request.type, request.File, cancellationToken);
            var document = new Documents
            {
                Id = Guid.NewGuid(),
                SubjectId = request.SubjectId,
                Type = request.type,
                FileName = request.File.FileName,
                FilePath = link

            };
            await _documentResposity.AddDocument(document);
            
            return new DocumentDto
            {
                Id = document.Id,
                fileName = document.FileName,
                type = document.Type,
                filePath = document.FilePath
            };
        }

    }
}
