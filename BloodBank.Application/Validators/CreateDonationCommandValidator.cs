using BloodBank.Application.Commands.CreateDonation;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationCommandValidator()
        {
            RuleFor(x => x.DonatorId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .ExclusiveBetween(420, 470);

            RuleFor(x => x.Date)
                .GreaterThan(DateTime.MinValue);
        }
    }
}
