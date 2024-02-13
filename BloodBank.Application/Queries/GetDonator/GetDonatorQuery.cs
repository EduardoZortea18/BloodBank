using BloodBank.Application.Models;
using BloodBank.Application.Models.Donator;
using MediatR;

namespace BloodBank.Application.Queries.GetDonator
{
    public class GetDonatorQuery : IRequest<Result<DonatorResponseModel>>
    {
        public int Id { get; private set; }

        public GetDonatorQuery(int id)
        {
            Id = id;
        }
    }
}
