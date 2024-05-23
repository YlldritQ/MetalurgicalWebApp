

using backend_dotnet7.Core.Enum;

namespace backend_dotnet7.Core.Entities
{
    public class OrderEntity : BaseEntity<long>
    {
       
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public string Address { get; set; } 
     
        public string Brand { get; set; }

        //Relations
        public ICollection<ProductOrder> ProductOrders { get; set; }

        //Vendosim relacionin e ardhshem per tabelen tjeter

    }
}
