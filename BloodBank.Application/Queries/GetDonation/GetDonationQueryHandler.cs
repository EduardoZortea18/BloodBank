using BloodBank.Application.Models;
using BloodBank.Application.Models.Address;
using BloodBank.Application.Models.Donation;
using BloodBank.Application.Models.Donator;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonation
{
    public class GetDonationQueryHandler : IRequestHandler<GetDonationQuery, Result<DonationResponseModel>>
    {
        private IDonationRepository _repository;

        public GetDonationQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<DonationResponseModel>> Handle(GetDonationQuery query, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetOneWithIncludes(x => x.Id == query.Id, it => it.Donator);

            return donation != null
                ? new Result<DonationResponseModel>(CreateNewDonationModel(donation), string.Empty)
                : new Result<DonationResponseModel>("Donation record does not exist", true);
        }

        private DonationResponseModel CreateNewDonationModel(Donation donation)
            => new DonationResponseModel(donation.Date, donation.Quantity, CreateNewDonatorModel(donation.Donator));

        private DonatorResponseModel CreateNewDonatorModel(Donator donator)
            => new DonatorResponseModel(
                donator.FullName,
                donator.Email,
                donator.BirthDate,
                donator.Gender,
                donator.Weight,
                donator.BloodType,
                donator.RhFactor,
                new FullAddressResponseModel(
                    donator.Address.ZipCode,
                    donator.Address.PublicArea,
                    donator.Address.City,
                    donator.Address.State));
    }
}

