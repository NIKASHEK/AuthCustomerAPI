namespace AuthCustomerAPI.Repository.Customer
{
    using AuthCustomerAPI.Models;
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        IEnumerable<Customer> Filter(string? lastName, string? firstNAme);
        void SaveChanges();
    }
}
