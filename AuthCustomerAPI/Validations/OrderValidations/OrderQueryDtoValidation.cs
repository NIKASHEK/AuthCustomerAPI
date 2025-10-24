using AuthCustomerAPI.Models.OrderDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.OrderValidations
{
    public class OrderQueryDtoValidation : AbstractValidator<OrderQueryDto>
    {
        public OrderQueryDtoValidation()
        {
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than 0")
                .When(x => x.TotalAmount.HasValue);
        }
    }
}
