using BloodBank.Application.Models;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock
{
    public class CreateBloodStockCommand : IRequest<Result<int>>
    {
        public BloodType BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public int Quantity { get; private set; }
        public Donator Donator { get; private set; }

        public CreateBloodStockCommand(BloodType bloodType, RhFactorEnum rhFactor, int quantity, Donator donator)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Quantity = quantity;
            Donator = donator;
        }
    }
}
