using BloodBank.Application.Models;
using BloodBank.Application.Validators;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock
{
    public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, Result<int>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly CreateBloodStockCommandValidator _validator;

        public CreateBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
            _validator = new CreateBloodStockCommandValidator();
        }

        public async Task<Result<int>> Handle(CreateBloodStockCommand command, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(command);

            if (!validationResult.IsValid)
            {
                return new Result<int>(string.Join(" - ", validationResult.Errors.Select(x => x.ErrorMessage)), true);
            }

            var newBloodStock = new BloodStock(command.Donator.BloodType, command.Donator.RhFactor, command.Quantity);

            await _bloodStockRepository.Create(newBloodStock);

            return new Result<int>(newBloodStock.Id, string.Empty);
        }
    }
}
