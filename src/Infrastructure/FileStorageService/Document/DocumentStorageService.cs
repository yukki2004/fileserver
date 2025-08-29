using WebApplication4.src.Domain.Interfaces;
namespace WebApplication4.src.Infrastructure.FileStorageService.Document
{
    public class DocumentStorageService : IDocumentFileService
    {
        private readonly string _rootPath;
        public DocumentStorageService(IConfiguration configuration)
        {
            _rootPath = configuration["FileStorage:RootPath"] ?? "FileStorage";
        }
        public async Task<string> AddDocumentFolder(string subjectCode, string type, IFormFile formFile, CancellationToken cancellationToken)
        {
            var documentPath = Path.Combine(_rootPath, subjectCode, type);
            if (!Directory.Exists(documentPath))
            {
                Directory.CreateDirectory(documentPath);
            }
            var filePath = Path.Combine(documentPath, formFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream, cancellationToken);
            }
            var relativePath = Path.Combine(subjectCode, type, formFile.FileName)
                       .Replace("\\", "/");

            return relativePath;

        }
        public async Task DeleteDocumentFolder(string subjectCode, string type, string filename, CancellationToken cancellationToken)
        {
            var filePath = Path.Combine(_rootPath, subjectCode, type, filename);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            await Task.CompletedTask;
        }
    }
}
