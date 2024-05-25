namespace backend_dotnet7.Core.Entities
{
    public class Location:BaseEntity<long>
    {
        public string LocationName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Time { get; set; }

        //Relation
        public List<TerminLocation> TerminLocations { get; set; }
    }
}
