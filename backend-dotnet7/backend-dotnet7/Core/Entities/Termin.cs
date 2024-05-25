﻿namespace backend_dotnet7.Core.Entities
{
    public class Termin:BaseEntity<long>
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Time { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }

        //Relation
        public List<TerminLocation> TerminLocations { get; set; }
    }

}
