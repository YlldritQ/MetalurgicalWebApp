namespace backend_dotnet7.Core.Dtos.Orders
{
    public class CreateUpdateOrderDto
    {
        public decimal Total { get; set; }
        public string Address { get; set; } 
<<<<<<< HEAD
<<<<<<< HEAD

=======
        public string PaymentMethod { get; set; } 
>>>>>>> parent of 88abc09 (Order Component)
=======
        public string PaymentMethod { get; set; } 
>>>>>>> parent of 88abc09 (Order Component)
        public long ProductId {  get; set; }
        public string Brand { get; set; } 
    }
}
