using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;

public interface ITripService
{
    public Task<IEnumerable<Trip>> GetAllAsync();
    public Task<Trip> GetByIdAsync(Guid id);
    public Task<Guid> AddAsync(TripDto tripdto);
    public Task<Guid> UpdateAsync(Guid Id, TripDto tripdto);
    public Task DeleteAsync(Guid Id);
}

