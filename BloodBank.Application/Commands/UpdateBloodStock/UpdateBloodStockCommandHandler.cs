using BloodBank.Application.Models;
using BloodBank.Application.Validators;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Events;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Result<BloodStock>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly UpdateBloodStockCommandValidator _validator;

        private const int MININUM_LEVEL = 400;

        public UpdateBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
            _validator = new UpdateBloodStockCommandValidator();
        }

        public async Task<Result<BloodStock>> Handle(UpdateBloodStockCommand command, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(command);

            if (!validationResult.IsValid)
            {
                return new Result<BloodStock>(string.Join(" - ", validationResult.Errors.Select(x => x.ErrorMessage)), true);
            }

            var bloodStock = await _bloodStockRepository.GetOne(x => x.Id == command.Id);

            if (bloodStock is null)
            {
                return new Result<BloodStock>("Record not found", true);
            }

            bloodStock.ChangeQuantity(bloodStock.Quantity + command.Quantity);


            if (bloodStock.Quantity < MININUM_LEVEL)
            {
                var bloodStockLevelEvent = new BloodStockLevelEvent(bloodStock.Id, bloodStock.BloodType, bloodStock.RhFactor);
                bloodStock.AddDomainEvent(bloodStockLevelEvent);
            }

            await _bloodStockRepository.Update(bloodStock);

            return new Result<BloodStock>(bloodStock, string.Empty);
        }
    }
}
