namespace backend_dotnet7.Core.Dtos.HeatTreatment
{
    public class HeatTreatmentDto
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string Temperature { get; set; }
        public string TimeDuration { get; set; }
        public string CoolingMethod { get; set; }
        public string Purpose { get; set; }
        public int CorrosionId { get; set; }
    }
}
