using AuthCustomerAPI.Models.CustomerDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.CustomerValidations
{
    public class CustomerQueryDtoValidation : AbstractValidator<CustomerQueryDto>
    {
        public CustomerQueryDtoValidation()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(40).WithMessage("Enter no more than 40 character!");

            RuleFor(x => x.LastName)
                .MaximumLength(40).WithMessage("Enter no more than 40 character!");
        }
    }
}
