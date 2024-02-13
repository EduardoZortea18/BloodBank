using BloodBank.Domain.Entities;
using System.Linq.Expressions;

namespace BloodBank.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task<T> GetOne(Expression<Func<T, bool>> expression);
        Task<T> GetOneWithIncludes(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAll();
        Task SaveChangesAsync();
    }
}
