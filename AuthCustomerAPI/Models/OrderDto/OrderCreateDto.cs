namespace AuthCustomerAPI.Models.OrderDto
{
    public class OrderCreateDto
    {
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
    }
}
