using BloodBank.Application.Models;
using BloodBank.Domain.Enums;
using MediatR;
using System.Text;

namespace BloodBank.Application.Queries.GetBloodStokReport
{
    public class GetBloodStockReportQuery : IRequest<Result<StringBuilder>>
    {
        public BloodType BloodType { get; private set; }

        public GetBloodStockReportQuery(BloodType bloodType)
        {
            BloodType = bloodType;
        }
    }
}
