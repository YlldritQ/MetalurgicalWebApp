namespace backend_dotnet7.Core.Entities
{
    public class TerminLocation:BaseEntity<long>
    {
        public long TerminId { get; set; }
        public Termin Termin { get; set; }
        public long LocationId { get; set; }
        public Location Location { get; set; }
    }
}
