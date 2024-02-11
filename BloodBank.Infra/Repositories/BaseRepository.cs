using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly BloodBankContext _context;

        public BaseRepository(BloodBankContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetOne(Func<T, bool> expression)
            => await _context.Set<T>().FindAsync(expression);

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
