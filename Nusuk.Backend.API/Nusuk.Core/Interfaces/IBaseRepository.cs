using Nusuk.Core.Consts;
using System.Linq.Expressions;

namespace Nusuk.Core.Interfaces;

public interface IBaseRepository<T> where T : class
{
    T GetById(Guid Id);
    IEnumerable<T> GetAll();
    T Find(Expression<Func<T, bool>> predicate, string[] includes = null);
    IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, string[] includes);
    IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int take, int skip);
    IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int? take, int? skip,
        Expression<Func<T, object>> orederBy = null, string OrderByDirection = OrderBy.Ascending);


    //Async
    Task<T> GetByIdAsync(Guid id, string[] includes = null);
    Task<T> GetByIdAsync(Guid id);
    Task<T?> GetByItemAsync(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, string[] includes = null);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
}
