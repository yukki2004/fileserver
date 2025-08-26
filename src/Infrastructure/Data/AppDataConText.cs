using Microsoft.EntityFrameworkCore;
using WebApplication4.src.Domain.Entities;

namespace WebApplication4.src.Infrastructure.Data
{
    public class AppDataConText : DbContext
    {
        public AppDataConText(DbContextOptions<AppDataConText> options) : base(options) { }
        public DbSet<Subjects> Subjects => Set<Subjects>();
        public DbSet<Documents> Documents => Set<Documents>();
    }
}
