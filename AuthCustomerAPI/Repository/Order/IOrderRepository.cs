namespace AuthCustomerAPI.Repository.Order
{
    using AuthCustomerAPI.Models;
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        IEnumerable<Order> Filter(decimal? totalAmount);
        void SaveChanges();
    }
}
