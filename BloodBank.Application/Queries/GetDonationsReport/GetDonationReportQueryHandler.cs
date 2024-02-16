using BloodBank.Application.Models;
using BloodBank.Application.Models.Address;
using BloodBank.Application.Models.Donation;
using BloodBank.Application.Models.Donator;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using MediatR;
using System.Text;

namespace BloodBank.Application.Queries.GetDonationsReport
{
    public class GetDonationReportQueryHandler : IRequestHandler<GetDonationReportQuery, Result<string>>
    {
        private readonly IDonationRepository _repository;

        public GetDonationReportQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Handle(GetDonationReportQuery query, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAllWithFilters(x => x.Date < DateTime.Today.AddDays(-30), it => it.Donator);

            var sb = new StringBuilder();


            sb.AppendLine("id;date;quantity;rhFactor;bloodType;fullName;email");
            foreach (var item in donations)
            {
                sb.AppendLine($"{item.Id};{item.Date};{item.Quantity};{item.Donator.RhFactor};{item.Donator.BloodType};{item.Donator.FullName};{item.Donator.Email};");
            }

            return new Result<string>(sb.ToString(), string.Empty);
        }
    }
}
