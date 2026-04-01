using FluentValidation;

namespace Bookly.Application.Features.Commands.Auth.Register;
public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {

        RuleFor(f => f.FirstName)
            .NotEmpty().WithMessage("İsim Boş Olamaz!")
            .MaximumLength(100).WithMessage("İsim En Fazla 100 Karakter Olabilir!")
            .MinimumLength(3).WithMessage("İsim En Az 3 Karakter Olabilir!");


        RuleFor(f => f.LastName)
            .NotEmpty().WithMessage("Soyisim Boş Olamaz!")
            .MaximumLength(100).WithMessage("Soyisim En Fazla 100 Karakter Olabilir!")
            .MinimumLength(3).WithMessage("Soyisim En Az 2 Karakter Olabilir!");

        RuleFor(f => f.Email)
              .NotEmpty().WithMessage("Email Boş Olamaz!")
              .EmailAddress().WithMessage("Geçerli Bir Mail Adresi Giriniz!");

        RuleFor(f => f.Password)
            .NotEmpty().WithMessage("Şifre Boş Olamaz!")
            .MinimumLength(6).WithMessage("Şifre En Az 6 Karakter Olmalıdır!")
            .Matches("[0-9]").WithMessage("Şifre En Az 1 Rakam İçermelidir!");
    }
}
