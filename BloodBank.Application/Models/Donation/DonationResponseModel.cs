using BloodBank.Application.Models.Donator;

namespace BloodBank.Application.Models.Donation
{
    public class DonationResponseModel
    {
        public DateTime Date { get; private set; }
        public int Quantity { get; private set; }
        public DonatorResponseModel Donator { get; private set; }

        public DonationResponseModel(DateTime date, int quantity, DonatorResponseModel donator)
        {
            Date = date;
            Quantity = quantity;
            Donator = donator;
        }
    }
}
