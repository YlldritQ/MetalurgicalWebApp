using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class Product_Order:BaseEntity<long>
    {


        public long ProductId { get; set; }
        public Product Product { get; set; }
   
        public long OrderId { get; set; }
        public OrderEntity Order { get; set; }
   
    }
}
