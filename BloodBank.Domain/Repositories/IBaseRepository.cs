using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task<T> GetOne(Func<T, bool> expression);
        Task<List<T>> GetAll();
        Task SaveChangesAsync();
    }
}
