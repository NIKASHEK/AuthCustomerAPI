using AuthCustomerAPI.Data;
using AuthCustomerAPI.Models.UserDto;
using Microsoft.AspNetCore.Identity;

namespace AuthCustomerAPI.Service.Auth
{
    using AuthCustomerAPI.Models;
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(AppDBContext context, IPasswordHasher<User> passwordHasher, ITokenService tokenService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }
        public string? Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if(result == PasswordVerificationResult.Failed)
                return null;

            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}
