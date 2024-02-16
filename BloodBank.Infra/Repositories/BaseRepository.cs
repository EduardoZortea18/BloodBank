using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<T> GetOne(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().AsNoTracking().Where(expression).FirstOrDefaultAsync();

        public async virtual Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetOneWithIncludes(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = SetIncludes(includes);
            return await query.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllWithFilters(Expression<Func<T, bool>> expression)
           => await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync();

        private IQueryable<T> SetIncludes(Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
