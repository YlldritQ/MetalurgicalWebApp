namespace backend_dotnet7.Core.Entities
{
    public class Termin:BaseEntity<long>
    {
        public DateTime Orari { get; set; }
        public string EmriKlientit { get; set; }
        public string Lokacioni { get; set; }
    }
}
