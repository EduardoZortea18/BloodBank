using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Repositories
{
    public interface IDonationRepository : IBaseRepository<Donation>
    {
        Task<List<Donation>> GetAllByDonator(int donatorId);
    }
}
