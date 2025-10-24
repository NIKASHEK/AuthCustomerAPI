namespace AuthCustomerAPI.Repository.Order
{
    using AuthCustomerAPI.Data;
    using AuthCustomerAPI.Models;
    using System.Collections.Generic;

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;

        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }

        public IEnumerable<Order> Filter(decimal? totalAmount)
        {
            var orders = _context.Orders.AsQueryable();
            if (totalAmount.HasValue)
                orders = orders.Where(o => o.TotalAmount >= totalAmount);
            return orders.ToList();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order? GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
