using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;

namespace BloodBank.Infra.Repositories
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(BloodBankContext context) : base(context)
        {
        }
    }
}
