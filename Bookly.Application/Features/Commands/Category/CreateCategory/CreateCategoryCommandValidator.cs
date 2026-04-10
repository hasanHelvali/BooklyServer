using FluentValidation;

namespace Bookly.Application.Features.Commands.Category.CreateCategory;

internal class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x=>x.Name).NotEmpty().NotNull().WithMessage("Kategori İsmi Boş Olamaz.");
    }
}
