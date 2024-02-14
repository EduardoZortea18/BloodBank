using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infra.Repositories
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        private readonly BloodBankContext _context;

        public DonationRepository(BloodBankContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Donation>> GetAllByDonator(int donatorId)
            => await _context.Donations.Where(x => x.DonatorId == donatorId && x.Active).Include(x => x.Donator).ToListAsync();
    }
}
