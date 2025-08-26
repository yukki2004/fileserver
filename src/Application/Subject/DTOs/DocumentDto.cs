namespace WebApplication4.src.Application.Subject.DTOs
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public  string type { get;set; } = null!;
        public string fileName { get; set; } = null!;
        public string filePath { get; set; } = null!;   
    }
}
