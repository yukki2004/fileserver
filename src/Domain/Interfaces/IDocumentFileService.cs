namespace WebApplication4.src.Domain.Interfaces
{
    public interface IDocumentFileService
    {
        public Task<string> AddDocumentFolder(string subjectCode, string type, IFormFile file, CancellationToken cancellationToken);
        public Task DeleteDocumentFolder(string subjectCode, string type, string filename, CancellationToken cancellationToken);
    }
}
