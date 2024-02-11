using BloodBank.Application.Models;
using BloodBank.Application.Models.Address;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonator
{
    public class CreateDonatorCommand : IRequest<Result<int>>
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public AddressRequestModel Address { get; private set; }

        public CreateDonatorCommand(
            string fullName,
            string email,
            DateTime birthDate,
            Gender gender,
            double weight,
            BloodType bloodType,
            RhFactorEnum rhFactor,
            AddressRequestModel address)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
        }
    }
}
