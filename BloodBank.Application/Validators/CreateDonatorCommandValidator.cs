using BloodBank.Application.Commands.CreateDonator;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class CreateDonatorCommandValidator : AbstractValidator<CreateDonatorCommand>
    {
        public CreateDonatorCommandValidator()
        {
            RuleFor(x => x.FullName)
                .Length(2, 50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.RhFactor)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Gender)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.BloodType)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.BirthDate)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.MinValue)
                .Must(IsOfAge);

            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Address)
                .SetValidator(new AddressValidator());
        }

        private bool IsOfAge(DateTime birthDate) => DateTime.Today.Year - birthDate.Year > 18;
    }
}
