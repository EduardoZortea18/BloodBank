using BloodBank.Application.Models;
using BloodBank.Application.Models.Donation;
using MediatR;

namespace BloodBank.Application.Queries.GetDonation
{
    public class GetDonationQuery : IRequest<Result<DonationResponseModel>>
    {
        public int Id { get; private set; }
        public GetDonationQuery(int id)
        {
            Id = id;
        }
    }
}
