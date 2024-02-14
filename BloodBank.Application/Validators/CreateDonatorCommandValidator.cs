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

            RuleFor(x => x.BirthDate)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.MinValue);

            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Address)
                .SetValidator(new AddressValidator());
        }
    }
}
