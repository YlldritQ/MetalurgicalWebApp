using System.Security.Cryptography;

namespace backend_dotnet7.Core.Dtos.Termin
{
    public class TerminDto
    {
        public long Id { get; set; }
        public DateTime Orari { get; set; }
        public string EmriKlientit { get; set; }
        public string Lokacioni { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }
}

