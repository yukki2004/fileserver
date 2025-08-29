using WebApplication4.src.Domain.Entities;  
using WebApplication4.src.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication4.src.Infrastructure.Data;  
namespace WebApplication4.src.Infrastructure.Resposity
{
    public class DocumentResposity : IDocumentResposity
    {
        public readonly AppDataConText _context;
        public DocumentResposity(AppDataConText context)
        {
            _context = context;
        }
        public async Task AddDocument(Documents document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDocument(Guid id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateDocument(Documents documents)
        {
            _context.Documents.Update(documents);
            await _context.SaveChangesAsync();
        }
        public async Task<Documents?> GetDocumentById(Guid id)
        {
            return await _context.Documents.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
