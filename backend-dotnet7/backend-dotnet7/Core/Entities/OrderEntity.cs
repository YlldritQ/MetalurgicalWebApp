﻿

namespace backend_dotnet7.Core.Entities
{
    public class OrderEntity : BaseEntity<long>
    {
       
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public string Address { get; set; } 
<<<<<<< HEAD
     
=======
        public string PaymentMethod { get; set; }
>>>>>>> parent of 88abc09 (Order Component)
        public string Brand { get; set; }

        //Relations
        public ICollection<ProductOrder> ProductOrders { get; set; }

        //Vendosim relacionin e ardhshem per tabelen tjeter

    }
}
