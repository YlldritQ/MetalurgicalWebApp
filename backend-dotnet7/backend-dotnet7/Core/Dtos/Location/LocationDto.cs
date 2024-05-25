namespace backend_dotnet7.Core.Dtos.Location
{
    public class LocationDto
    {
        public string LocationName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Time { get; set; }
    }
}
