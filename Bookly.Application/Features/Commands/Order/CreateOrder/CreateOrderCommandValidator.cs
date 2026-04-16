using FluentValidation;

namespace Bookly.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Items).NotEmpty().WithMessage("Sipariş en az bir ürün içermelidir.");
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.ProductId).NotEmpty();
            item.RuleFor(x => x.Quantity).GreaterThan(0);
        });
    }
}
