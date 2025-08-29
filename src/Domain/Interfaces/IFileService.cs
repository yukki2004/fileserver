
namespace WebApplication4.src.Domain.Interfaces
{
    public interface IFileService
    {
        public Task AddSubjectFolder(string subjectCode, CancellationToken cancellationToken);
        public Task DeleteSubjectFolder(string subjectCode, CancellationToken cancellationToken);
    }
}
