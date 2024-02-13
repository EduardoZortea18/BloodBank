using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonation
{
    public class CreateDonationCommand : IRequest<Result<int>>
    {
        public int DonatorId { get; private set; }
        public DateTime Date { get; private set; }
        public int Quantity { get; private set; }

        public CreateDonationCommand(int donatorId, DateTime date, int quantity)
        {
            DonatorId = donatorId;
            Date = date;
            Quantity = quantity;
        }
    }
}
