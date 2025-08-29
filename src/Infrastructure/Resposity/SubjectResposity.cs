using WebApplication4.src.Domain.Entities;
using WebApplication4.src.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication4.src.Application.Subject.DTOs;
using WebApplication4.src.Infrastructure.Data;
namespace WebApplication4.src.Infrastructure.Resposity
{
    public class SubjectResposity : ISubjectResposity
    {
        public readonly AppDataConText _context;
        public SubjectResposity(AppDataConText context)
        {
            _context = context;
        }
        public async Task AddSubject(Subjects subjects)
        {
            await _context.Subjects.AddAsync(subjects);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSubject(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateSubject(Subjects subjects)
        {
            _context.Subjects.Update(subjects);
            await _context.SaveChangesAsync();
        }
        public async Task<Subjects?> GetSubjectById(Guid id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }

    }
}
