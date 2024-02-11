using BloodBank.Domain.Entities.ValueObjects;
using BloodBank.Domain.Enums;

namespace BloodBank.Domain.Entities
{
    public class Donator : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public Address Address { get; private set; }

        public List<Donation> Donations { get; private set; }

        public Donator(
            string fullName,
            string email,
            DateTime birthDate,
            Gender gender,
            double weight,
            BloodType bloodType,
            RhFactorEnum rhFactor,
            Address address)
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

        public Donator()
        {
        }
    }
}
