namespace backend_dotnet7.Core.Dtos.Orders
{
    public class CreateUpdateOrderDto
    {
        public decimal Total { get; set; }
        public String Address { get; set; }
        public String PaymentMethod { get; set; }
    }
}
