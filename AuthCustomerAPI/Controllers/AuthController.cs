using AuthCustomerAPI.Models.UserDto;
using AuthCustomerAPI.Service.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AuthCustomerAPI.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var token = _authService.Login(request);

            if (token == null)
            {
                var failedResponse = new LoginResponse
                {
                    Message = "Invalid username or password"
                };
                return Unauthorized(failedResponse);
            }


            var response = new LoginResponse
            {
                Token = token,
                Message = "Successful login"
            };

            return Ok(response);
        }
    }
}
