using Microsoft.EntityFrameworkCore;
using Nusuk.Core.Common;
using Nusuk.Core.Consts;
using Nusuk.Core.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Nusuk.Infrastructure.Repositories;

public class BaseRepository<T>(DbContext _context) : IBaseRepository<T> where T : BaseEntity
{
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T GetById(Guid Id)
    {
        return _context.Set<T>().Find(Id);
    }
    public T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return query.SingleOrDefault(predicate);
    }
    public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return query.Where(predicate).ToList();

    }
    public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int take, int skip)
    {
        return _context.Set<T>().Where(predicate).Take(take).Skip(skip).ToList();
    }
    public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int? take, int? skip,
       Expression<Func<T, object>> orederBy = null, string orderByDirection = OrderBy.Ascending)
    {
        IQueryable<T> query = _context.Set<T>().Where(predicate);
        if(take.HasValue)
            query = query.Take(take.Value);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if(orederBy != null)
        {
            if (orderByDirection==OrderBy.Ascending)
                query= query.OrderBy(orederBy) ;
            else
                query = query.OrderBy(orederBy);
        }
        return query.ToList();
    }
    public void Add(T entity)
    {
        _context.Add(entity);
    }
    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        _context.Update(entity);
    }

    // Asynchronous 
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid Id)
    {
        return await _context.Set<T>().FindAsync(Id);
    }
    public async Task<T> GetByIdAsync(Guid Id, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.FirstOrDefaultAsync(x=>x.Id==Id);
    }
    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);
        return await query.SingleOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);
        return await query.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, int take, int skip)
    {
        return await _context.Set<T>().Where(predicate).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate,
            int? take = null,
            int? skip = null,
            Expression<Func<T, object>> orderBy = null,
            string orderByDirection = OrderBy.Ascending)
    {
        IQueryable<T> query = _context.Set<T>().Where(predicate);

        if (orderBy != null)
        {
            query = orderByDirection == OrderBy.Ascending
                ? query.OrderBy(orderBy)
                : query.OrderByDescending(orderBy);
        }

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return await query.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.AddRangeAsync(entities);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(T entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        _context.Update(entity); await Task.CompletedTask;
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
            entity.DeletedAt = DateTime.UtcNow;

        _context.UpdateRange(entities);
    }
}

