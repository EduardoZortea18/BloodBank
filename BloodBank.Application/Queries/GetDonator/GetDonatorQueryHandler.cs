using BloodBank.Application.Models;
using BloodBank.Application.Models.Address;
using BloodBank.Application.Models.Donator;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonator
{
    public class GetDonatorQueryHandler : IRequestHandler<GetDonatorQuery, Result<DonatorResponseModel>>
    {
        private IDonatorRepository _repository;

        public GetDonatorQueryHandler(IDonatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<DonatorResponseModel>> Handle(GetDonatorQuery query, CancellationToken cancellationToken)
        {
            var donator = await _repository.GetOne(x => x.Id == query.Id);

            return donator != null
                ? new Result<DonatorResponseModel>(CreateNewDonatorModel(donator), string.Empty)
                : new Result<DonatorResponseModel>("Donator does not exist", true);
        }

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
