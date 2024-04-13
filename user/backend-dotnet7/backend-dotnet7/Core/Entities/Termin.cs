using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace backend_dotnet7.Core.Entities
{
    public class Termin
    {
        [Key]
        public int ID { get; set; }
        public string ClientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
    }

} 
