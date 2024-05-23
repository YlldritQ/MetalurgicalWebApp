using backend_dotnet7.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class Product:BaseEntity<long>
    {

        public string Brand { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        

        //Relation
        public ICollection<ProductOrder> ProductOrders { get; set; } 
    }
}
