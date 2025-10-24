using AuthCustomerAPI.Models.OrderDto;
using FluentValidation;

namespace AuthCustomerAPI.Validations.OrderValidations
{
    public class OrderPatchDtoValidation : AbstractValidator<OrderPatchDto>
    {
        public OrderPatchDtoValidation()
        {
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than 0")
                .When(x => x.TotalAmount.HasValue);
        }
    }
}
