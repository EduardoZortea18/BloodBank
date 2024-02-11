using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;

namespace BloodBank.Infra.Repositories
{
    public class BloodStockRepository : BaseRepository<BloodStock>, IBloodStockRepository
    {
        public BloodStockRepository(BloodBankContext context) : base(context)
        {
        }
    }
}
