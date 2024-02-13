using BloodBank.Application.Models;
using BloodBank.Application.Models.Address;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Entities.ValueObjects;
using BloodBank.Domain.Repositories;
using Flurl.Http;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonator
{
    public class CreateDonatorCommandHandler : IRequestHandler<CreateDonatorCommand, Result<int>>
    {
        private IDonatorRepository _repository;
        private const string ZIP_CODE_URL = "https://viacep.com.br/ws/";
        private const string RESPONSE_FORMAT = "json";

        public CreateDonatorCommandHandler(IDonatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateDonatorCommand command, CancellationToken cancellationToken)
        {
            var existingDonator = await _repository.GetOne(x => string.Equals(x.Email, command.Email));

            if (existingDonator != null)
            {
                return new Result<int>("A record with this email already exists", true);
            }

            var fullAdress = await GetAddress(command.Address.ZipCode);
            var newDonator = CreateNewDonatorEntity(command, fullAdress);

            await _repository.Create(newDonator);

            return new Result<int>(newDonator.Id, string.Empty);
        }

        private async Task<Address> GetAddress(string zipCode)
        {
            var flurlRequest = new FlurlRequest(ZIP_CODE_URL);

            var response = await flurlRequest
                .AppendPathSegment(zipCode)
                .AppendPathSegment(RESPONSE_FORMAT)
                .GetJsonAsync<FullAddressResponseModel>();

            return !HasNullProperties(response)
                ? new Address(response.Logradouro, response.Localidade, response.Uf, response.Cep)
                : throw new ArgumentNullException("Null values from response");
        }

        public static bool HasNullProperties<T>(T obj)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.GetValue(obj) == null)
                {
                    return true;
                }
            }

            return false;
        }

        private Donator CreateNewDonatorEntity(CreateDonatorCommand command, Address address)
            => new Donator(
                command.FullName,
                command.Email,
                command.BirthDate,
                command.Gender,
                command.Weight,
                command.BloodType,
                command.RhFactor,
                address);

    }
}
