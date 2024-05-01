using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class OrderEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Total { get; set; }

        public String Address { get; set; }
        public String PaymentMethod { get; set; }
    }
}
