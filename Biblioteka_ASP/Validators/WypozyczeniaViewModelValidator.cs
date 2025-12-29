using Biblioteka_ASP.ViewModels;
using FluentValidation;

namespace Biblioteka_ASP.Validators
{
    public class WypozyczeniaViewModelValidator : AbstractValidator<WypozyczeniaViewModel>
    {
        public WypozyczeniaViewModelValidator()
        {
            RuleFor(x => x.ID_Ksiazki)
                .GreaterThan(0).WithMessage("ID książki jest wymagane");

            RuleFor(x => x.TytulKsiazki)
                .MaximumLength(200).WithMessage("Tytuł książki nie może przekraczać 200 znaków.")
                .When(x => !string.IsNullOrEmpty(x.TytulKsiazki));

            RuleFor(x => x.ID_Klienta)
                .GreaterThan(0).WithMessage("ID klienta jest wymagane");

            RuleFor(x => x.ImieKlienta)
                .MaximumLength(100).WithMessage("Imię klienta nie może przekraczać 100 znaków.")
                .When(x => !string.IsNullOrEmpty(x.ImieKlienta));

            RuleFor(x => x.Data_Wypozyczenia)
                .NotEmpty().WithMessage("Data wypożyczenia jest wymagana.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data wypożyczenia nie może być w przyszłości.");

            RuleFor(x => x.Data_Zwrotu)
                .GreaterThanOrEqualTo(x => x.Data_Wypozyczenia).WithMessage("Data zwrotu nie może być wcześniejsza niż data wypożyczenia.")
                .When(x => x.Data_Zwrotu != default(DateTime));

            RuleFor(x => x.Kara)
                .GreaterThanOrEqualTo(0).WithMessage("Kara nie może być ujemna.");
        }
    }
}
