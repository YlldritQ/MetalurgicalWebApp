namespace backend_dotnet7.Core.Entities
{
    public class ProductOrder
    {
        public long OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
