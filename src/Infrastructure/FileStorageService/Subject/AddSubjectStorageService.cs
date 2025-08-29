using WebApplication4.src.Domain.Interfaces;
namespace WebApplication4.src.Infrastructure.FileStorageService.Subject
{
    public class AddSubjectStorageService : IFileService
    {
        private readonly string _rootPath;
        public AddSubjectStorageService(IConfiguration configuration)
        {
            _rootPath = configuration["FileStorage:RootPath"] ?? "FileStorage";
        }
        public async Task AddSubjectFolder(string subjectCode, CancellationToken cancellationToken)
        {
            var subjectPath = Path.Combine(_rootPath, subjectCode);
            if (!Directory.Exists(subjectPath))
            {
                Directory.CreateDirectory(subjectPath);
            }
            string[] subFolders = { "dethi", "giaotrinh", "slide", "tailieukhac" };
            foreach (var folder in subFolders)
            {
                var folderPath = Path.Combine(subjectPath, folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            await Task.CompletedTask;

        }
        public async Task DeleteSubjectFolder(string subjectCode, CancellationToken cancellationToken)
        {
            var subjectPath = Path.Combine(_rootPath, subjectCode);
            if (Directory.Exists(subjectPath))
            {
                Directory.Delete(subjectPath, true);
            }
            await Task.CompletedTask;
        }
    }
}
