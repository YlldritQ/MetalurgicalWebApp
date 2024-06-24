using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class HeatTreatment
    {
        [Key]
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string Temperature { get; set; }
        public string TimeDuration { get; set; }
        public string CoolingMethod { get; set; }
        public string Purpose { get; set; }
        public int CorrosionId { get; set; }
        public Corrosion Corrosion { get; set; }
    }
}
