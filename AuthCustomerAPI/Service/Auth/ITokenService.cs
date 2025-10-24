using AuthCustomerAPI.Models;

namespace AuthCustomerAPI.Service.Auth
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
