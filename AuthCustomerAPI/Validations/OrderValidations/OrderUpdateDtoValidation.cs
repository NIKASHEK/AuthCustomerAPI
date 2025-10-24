using AuthCustomerAPI.Models.OrderDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.OrderValidations
{
    public class OrderUpdateDtoValidation : AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateDtoValidation() 
        {
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than 0");
        }
    }
}
