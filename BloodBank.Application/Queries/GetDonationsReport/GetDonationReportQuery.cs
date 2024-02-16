using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationsReport
{
    public class GetDonationReportQuery : IRequest<Result<string>>
    {
    }
}
