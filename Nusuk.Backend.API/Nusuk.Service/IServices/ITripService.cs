using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;

public interface ITripService
{
    public Task<PagedResult<Trip>> GetAllAsync(PaginationParameter pagination);
    public Task<Trip> GetByIdAsync(Guid id);
    public Task<Guid> AddAsync(TripDto tripdto);
    public Task<Guid> UpdateAsync(Guid Id, TripDto tripdto);
    public Task DeleteAsync(Guid Id);
    public Task<IEnumerable<object>> GetTripWithDetails();
}

