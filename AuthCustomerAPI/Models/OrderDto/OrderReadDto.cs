namespace AuthCustomerAPI.Models.OrderDto
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
    }
}
