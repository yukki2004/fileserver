using WebApplication4.src.Domain.Entities;
namespace WebApplication4.src.Domain.Interfaces
{
    public interface IDocumentResposity
    {
        public Task AddDocument(Documents document);
        public Task DeleteDocument(Guid id);
        public Task UpdateDocument(Documents documents);
        public Task<Documents?> GetDocumentById(Guid id);

    }
}
