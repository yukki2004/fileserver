using WebApplication4.src.Domain.Entities;
namespace WebApplication4.src.Domain.Interfaces
{
    public interface ISubjectResposity
    {
        public Task AddSubject(Subjects subjects);
        public Task DeleteSubject(Guid id);
        public Task UpdateSubject(Subjects subjects);
        public Task<Subjects?> GetSubjectById(Guid id);
    }
}
