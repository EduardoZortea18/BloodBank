using BloodBank.Application.Models;
using BloodBank.Application.Models.Donation;
using MediatR;

namespace BloodBank.Application.Queries.GetDonatorHistory
{
    public class GetDonationHistoryQuery : IRequest<Result<List<DonationResponseModel>>>
    {
        public int Id { get; private set; }

        public GetDonationHistoryQuery(int id)
        {
            Id = id;
        }
    }
}
