using BloodBank.Application.Models;
using BloodBank.Application.Validators;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using MediatR;
using System.Threading;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Result<BloodStock>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly UpdateBloodStockCommandValidator _validator;

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

            await _bloodStockRepository.Update(bloodStock);

            return new Result<BloodStock>(bloodStock, string.Empty);
        }
    }
}
