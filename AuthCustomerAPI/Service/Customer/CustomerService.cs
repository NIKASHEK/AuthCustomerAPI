using AuthCustomerAPI.Models.CustomerDto;

namespace AuthCustomerAPI.Service.Customer
{
    using AuthCustomerAPI.Models;
    using AuthCustomerAPI.Models.OrderDto;
    using AuthCustomerAPI.Repository.Customer;

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public CustomerReadDto CreateCustomer(CustomerCreateDto createDto)
        {
            var customer = new Customer()
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Phone = createDto.Phone,
                Email = createDto.Email,
            };
            _repo.Add(customer);
            _repo.SaveChanges();
            var readDto = new CustomerReadDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                UserName = customer.UserName,
            };
            return readDto;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _repo.GetById(id);
            _repo.Delete(customer);
            _repo.SaveChanges();
        }

        public IEnumerable<CustomerReadDto> FilterCustomer(CustomerQueryDto queryDto)
        {
            var readDtos = _repo.Filter(queryDto.LastName, queryDto.FirstName).Select( c => new CustomerReadDto 
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Phone = c.Phone,
                Email = c.Email,
                UserName= c.UserName,
            });
            return readDtos;
        }

        public IEnumerable<CustomerReadDto> GetAllCustomers()
        {
            return _repo.GetAll().Select(c => new CustomerReadDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Phone = c.Phone,
                Email = c.Email,
                UserName = c.UserName
            });
        }

        public CustomerReadDto? GetCustomer(int id)
        {
            var customer =  _repo.GetById(id);
            if(customer == null)
                return null;
            var readDto = new CustomerReadDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                UserName = customer.UserName,
                Orders = customer.Orders?.Select(o => new OrderReadDto
                {
                    Id = o.Id,
                    TotalAmount = o.TotalAmount,
                    CreatedDate = o.CreatedDate,
                    CustomerId = o.CustomerId
                }).ToList()
            };
            return readDto;
        }

        public bool PatchCustomer(int id, CustomerPatchDto patchDto)
        {
            var customer = _repo.GetById(id);
            if(customer == null)
                return false;

            if(!string.IsNullOrWhiteSpace(patchDto.FirstName))
                customer.FirstName = patchDto.FirstName;

            if(!string.IsNullOrWhiteSpace(patchDto.LastName))
                customer.LastName = patchDto.LastName;

            if (!string.IsNullOrWhiteSpace(patchDto.Phone))
                customer.Phone = patchDto.Phone;

            if (!string.IsNullOrWhiteSpace(patchDto.Email))
                customer.Email = patchDto.Email;
            _repo.SaveChanges();

            return true;
        }

        public void UpdateCustomer(int id, CustomerUpdateDto updateDto)
        {
            var customer = _repo.GetById(id);

            customer.FirstName = updateDto.FirstName;
            customer.LastName = updateDto.LastName;
            customer.Phone = updateDto.Phone;
            customer.Email = updateDto.Email;
            
            _repo.SaveChanges();
        }
    }
}
