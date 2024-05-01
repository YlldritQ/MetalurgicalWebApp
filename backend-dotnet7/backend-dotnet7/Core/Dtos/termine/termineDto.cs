using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Dtos.termine
{
    public class termineDto
    {
        public string ClientName { get; set; }
       
        public string AppointmentTime { get; set; }
    }
}
