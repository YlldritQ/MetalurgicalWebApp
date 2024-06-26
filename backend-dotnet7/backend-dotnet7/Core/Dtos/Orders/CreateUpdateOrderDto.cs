﻿namespace backend_dotnet7.Core.Dtos.Orders
{
    public class CreateUpdateOrderDto
    {
        public decimal Total { get; set; }
        public string Address { get; set; } 
        public string PaymentMethod { get; set; } 
        public long ProductId {  get; set; }
        public string Brand { get; set; } 
    }
}
