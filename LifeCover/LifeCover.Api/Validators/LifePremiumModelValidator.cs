using FluentValidation;
using LifeCover.Api.Models;

namespace LifeCover.Api.Validators
{
    public class LifePremiumModelValidator : AbstractValidator<LifePremiumModel>
    {
        public LifePremiumModelValidator()
        {
            CascadeMode = CascadeMode.Continue;
            RuleFor(x => x.Occupation)
                .NotEmpty();
            RuleFor(a => a.Age)
                .GreaterThan(0)
                .When(d => d.DateOfBirth == null);
            RuleFor(d => d.DateOfBirth)
                .NotNull()
                .When(a => a.Age == null);
            RuleFor(x => x.SumInsured)
                .GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
