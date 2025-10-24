
namespace AuthCustomerAPI.Repository.Customer
{
    using AuthCustomerAPI.Data;
    using AuthCustomerAPI.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _context;

        public CustomerRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public IEnumerable<Customer> Filter(string? lastName, string? firstNAme)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstNAme))
                customers = customers.Where(c => c.LastName.StartsWith(lastName) && c.FirstName.StartsWith(firstNAme));
            else if (!string.IsNullOrEmpty(lastName))
                customers = customers.Where(c => c.LastName.StartsWith(lastName));
            else if (!string.IsNullOrEmpty(firstNAme))
                customers = customers.Where(c => c.LastName.StartsWith(firstNAme));
            
            return customers.ToList();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.Include(c => c.Orders).FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
