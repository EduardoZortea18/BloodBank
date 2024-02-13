using BloodBank.Application.Models;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommand : IRequest<Result<BloodStock>>
    {
        public int Id { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public int Quantity { get; private set; }

        public UpdateBloodStockCommand(BloodType bloodType, RhFactorEnum rhFactor, int quantity, int id)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Quantity = quantity;
        }
    }
}
