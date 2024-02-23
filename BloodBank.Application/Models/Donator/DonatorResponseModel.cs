using BloodBank.Application.Models.Address;
using BloodBank.Domain.Enums;

namespace BloodBank.Application.Models.Donator
{
    public sealed record DonatorResponseModel(
        string FullName,
        string Email,
        DateTime BirthDate,
        Gender Gender,
        double Weight,
        BloodType BloodType,
        RhFactorEnum RhFactor,
        FullAddressResponseModel Address);
}
