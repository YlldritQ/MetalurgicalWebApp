using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Dtos.termine
{
    public class termineDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Time { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
    }
}
