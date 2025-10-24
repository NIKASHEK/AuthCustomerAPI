namespace AuthCustomerAPI.Service.Customer
{
    using AuthCustomerAPI.Models.CustomerDto;

    public interface ICustomerService
    {
        IEnumerable<CustomerReadDto> GetAllCustomers();
        CustomerReadDto? GetCustomer(int id);
        CustomerReadDto CreateCustomer(CustomerCreateDto createDto);
        void DeleteCustomer(int id);
        void UpdateCustomer(int id, CustomerUpdateDto updateDto);
        IEnumerable<CustomerReadDto> FilterCustomer(CustomerQueryDto queryDto);
        bool PatchCustomer(int id, CustomerPatchDto patchDto);
    }
}
