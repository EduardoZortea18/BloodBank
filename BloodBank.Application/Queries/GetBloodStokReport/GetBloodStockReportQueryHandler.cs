using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;
using System.Text;

namespace BloodBank.Application.Queries.GetBloodStokReport
{
    public class GetBloodStockReportQueryHandler : IRequestHandler<GetBloodStockReportQuery, Result<string>>
    {
        private readonly IBloodStockRepository _repository;

        public GetBloodStockReportQueryHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Handle(GetBloodStockReportQuery query, CancellationToken cancellationToken)
        {
            var bloodStocks = await _repository.GetAllWithFilters(x => x.BloodType == query.BloodType);
            var sb = new StringBuilder();

            sb.AppendLine("id;bloodType;rhFactor");
            foreach (var item in bloodStocks)
            {
                sb.AppendLine($"{item.Id};{item.BloodType.ToString()};{item.RhFactor}");
            }

            return new Result<string>(sb.ToString(), string.Empty);
        }
    }
}
