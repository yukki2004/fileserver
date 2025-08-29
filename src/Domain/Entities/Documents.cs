namespace WebApplication4.src.Domain.Entities
{
    public class Documents
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public string Type { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string? FilePath { get; set; } 
    }
}
