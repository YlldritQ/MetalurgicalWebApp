using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class Corrosion
    {
        [Key]
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public string Environment { get; set; }
        public int CorrosionRate { get; set; }
        public string ProtectiveCoating { get; set; }
        public string Notes { get; set; }

        public ICollection<HeatTreatment> HeatTreatments { get; set; }
    }
}
