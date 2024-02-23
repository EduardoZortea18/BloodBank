using BloodBank.Application.Models.Donator;

namespace BloodBank.Application.Models.Donation
{
    public sealed record DonationResponseModel(DateTime Date, int Quantity, DonatorResponseModel Donator);
}
