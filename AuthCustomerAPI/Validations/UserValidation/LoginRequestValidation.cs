using AuthCustomerAPI.Models.UserDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.UserValidation
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is Required!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!");
        }
    }
}
