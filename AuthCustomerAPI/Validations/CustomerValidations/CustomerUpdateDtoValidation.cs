using AuthCustomerAPI.Models.CustomerDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.CustomerValidations
{
    public class CustomerUpdateDtoValidation : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidation()
        {
            RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("First name is required!")
                    .MaximumLength(40).WithMessage("Enter no more than 40 character!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required!")
                .MaximumLength(40).WithMessage("Enter no more than 40 character!");

            RuleFor(x => x.Phone)
                .MaximumLength(15).WithMessage("Enter no more than 15 digit!")
                .MinimumLength(3).WithMessage("Enter no  less than 3 digit!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Enter valid email!");
        }
    }
}
