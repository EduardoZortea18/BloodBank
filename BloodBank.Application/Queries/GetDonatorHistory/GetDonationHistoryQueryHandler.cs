using BloodBank.Application.Models;
using BloodBank.Application.Models.Address;
using BloodBank.Application.Models.Donation;
using BloodBank.Application.Models.Donator;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonatorHistory
{
    public class GetDonationHistoryQueryHandler : IRequestHandler<GetDonationHistoryQuery, Result<List<DonationResponseModel>>>
    {
        private readonly IDonationRepository _repository;

        public GetDonationHistoryQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<DonationResponseModel>>> Handle(GetDonationHistoryQuery query, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAllByDonator(query.Id);

            if (donations.Count > 0)
            {
                var response = donations.Select(CreateNewDonationModel).ToList();
                return new Result<List<DonationResponseModel>>(response, string.Empty);
            }

            return new Result<List<DonationResponseModel>>("Error on getting the data", true);
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
