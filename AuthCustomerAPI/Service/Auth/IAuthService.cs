using AuthCustomerAPI.Models.UserDto;

namespace AuthCustomerAPI.Service.Auth
{
    public interface IAuthService
    {
        string? Login(LoginRequest request);
    }
}
