using BloodBank.Application.Commands.UpdateBloodStock;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class UpdateBloodStockCommandValidator : AbstractValidator<UpdateBloodStockCommand>
    {
        public UpdateBloodStockCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
