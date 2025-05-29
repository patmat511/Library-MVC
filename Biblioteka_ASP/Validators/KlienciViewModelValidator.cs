using FluentValidation;
using Biblioteka_ASP.ViewModels;

namespace Biblioteka_ASP.Validators
{
    public class KlienciViewModelValidator : AbstractValidator<KlienciViewModel>
    {
        public KlienciViewModelValidator()
        {
            RuleFor(x => x.ID_Klienta)
                .GreaterThan(0).WithMessage("ID klienta musi być większe niż 0.");

            RuleFor(x => x.Imie)
                .NotEmpty().WithMessage("Imię jest wymagane.")
                .Length(2, 50).WithMessage("Imię musi mieć od 2 do 50 znaków.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email jest wymagany.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Podaj poprawny adres email.");

            RuleFor(x => x.Telefon)
                .NotEmpty().WithMessage("Telefon jest wymagany.")
                .Matches(@"^\+?\d{9,11}$").WithMessage("Telefon musi mieć od 9 do 11 cyfr i może zaczynać się od '+'.");

            RuleFor(x => x.Adres)
                .NotEmpty().WithMessage("Adres jest wymagany.")
                .Length(5, 100).WithMessage("Adres musi mieć od 5 do 100 znaków.");
        }
    }
}