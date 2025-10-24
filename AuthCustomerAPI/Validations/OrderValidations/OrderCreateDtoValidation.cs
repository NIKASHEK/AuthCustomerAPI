using AuthCustomerAPI.Models.OrderDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.OrderValidations
{
    public class OrderCreateDtoValidation: AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidation() 
        {
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than 0");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be greater than 0");
        }
    }
}
