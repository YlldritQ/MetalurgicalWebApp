namespace backend_dotnet7.Core.Dtos.Corrosion
{
    public class CorrosionDto
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public string Environment { get; set; }
        public int CorrosionRate { get; set; }
        public string ProtectiveCoating { get; set; }
        public string Notes { get; set; }
    }
}
