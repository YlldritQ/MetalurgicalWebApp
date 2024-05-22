using backend_dotnet7.Core.Enum;

namespace backend_dotnet7.Core.Dtos.Orders
{
    public class UpdateOrderdto
    {
        public decimal Total { get; set; }
        public string Address { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
    }
}
