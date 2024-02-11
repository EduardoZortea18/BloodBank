using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;

namespace BloodBank.Infra.Repositories
{
    public class DonatorRepository : BaseRepository<Donator>, IDonatorRepository
    {
        public DonatorRepository(BloodBankContext context) : base(context)
        {
        }
    }
}
