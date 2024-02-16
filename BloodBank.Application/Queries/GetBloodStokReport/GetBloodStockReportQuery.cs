using BloodBank.Application.Models;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStokReport
{
    public class GetBloodStockReportQuery : IRequest<Result<string>>
    {
        public BloodType BloodType { get; private set; }

        public GetBloodStockReportQuery(BloodType bloodType)
        {
            BloodType = bloodType;
        }
    }
}
