using FluentValidation;

namespace Bookly.Application.Features.Commands.Product.DeleteProductById;
public  class DeleteProductByIdCommandValidator : AbstractValidator<DeleteProductByIdCommandRequest>
{
    public DeleteProductByIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Silinecek Ürün İd'si Bulunamadı.");
    }
}
