using FluentValidation;

namespace Biblioteka_ASP.ViewModels
{
    public class GatunkiViewModelValidator : AbstractValidator<GatunkiViewModel>
    {
        public GatunkiViewModelValidator()
        {
            RuleFor(x => x.Gatunek)
                .NotEmpty().WithMessage("Nazwa gatunku jest wymagana.")
                .MaximumLength(100).WithMessage("Nazwa gatunku nie może przekraczać 100 znaków.");

            RuleFor(x => x.LiczbaKsiazek)
                .GreaterThanOrEqualTo(0).WithMessage("Liczba książek nie może być ujemna.");
        }
    }
}