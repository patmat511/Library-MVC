using Biblioteka_ASP.ViewModels;
using FluentValidation;

namespace Biblioteka_ASP.Validators
{
    public class KsiazkiViewModelValidator : AbstractValidator<KsiazkiViewModel>
    {
        public KsiazkiViewModelValidator()
        {
            RuleFor(x => x.Tytul)
                .NotEmpty().WithMessage("Tytuł książki jest wymagany.")
                .MaximumLength(200).WithMessage("Tytuł książki nie może przekraczać 200 znaków.");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("Autor książki jest wymagany.")
                .MaximumLength(100).WithMessage("Nazwisko autora nie może przekraczać 100 znaków.");

            RuleFor(x => x.Rok_Wydania)
                .InclusiveBetween(1, DateTime.Now.Year).WithMessage($"Rok wydania musi być między 1 a {DateTime.Now.Year}.");

            RuleFor(x => x.ID_Gatunku)
                .GreaterThan(0).WithMessage("ID gatunku musi być większe od 0.");

            RuleFor(x => x.NazwaGatunku)
                .MaximumLength(100).WithMessage("Nazwa gatunku nie może przekraczać 100 znaków.")
                .When(x => !string.IsNullOrEmpty(x.NazwaGatunku));

            RuleFor(x => x.Ilosc_Dostepna)
                .GreaterThanOrEqualTo(0).WithMessage("Ilość dostępna nie może być ujemna.");
        }
    }
}
