using AuthCustomerAPI.Models.CustomerDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.CustomerValidations
{
    public class CustomerPatchDtoValidation : AbstractValidator<CustomerPatchDto>
    {
        public CustomerPatchDtoValidation()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(40).WithMessage("Enter no more than 40 character!");

            RuleFor(x => x.LastName)
                .MaximumLength(40).WithMessage("Enter no more than 40 character!");

            RuleFor(x => x.Phone)
                .MaximumLength(15).WithMessage("Enter no more than 15 digit!")
                .MinimumLength(3).WithMessage("Enter no  less than 3 digit!")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Enter valid email!")
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}
