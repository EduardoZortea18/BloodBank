using BloodBank.Application.Commands.CreateBloodStock;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class CreateBloodStockCommandValidator : AbstractValidator<CreateBloodStockCommand>
    {
        public CreateBloodStockCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Donator)
                .NotEmpty()
                .NotNull();
        }
    }
}
