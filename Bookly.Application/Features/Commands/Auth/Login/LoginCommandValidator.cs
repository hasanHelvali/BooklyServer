using FluentValidation;
namespace Bookly.Application.Features.Commands.Auth.Login;
public class LoginCommandValidator: AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.");
    }
}
