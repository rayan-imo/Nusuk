using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;
public interface ICaravanService
{
    public Task<PagedResult<Caravan>> GetAllAsync(PaginationParameter pagination);
    public Task<Caravan> GetByIdAsync(Guid Id);
    public Task<Guid> AddAsync(CaravanDto caravanDto);
    public Task<Guid> UpdateAsync(Guid Id, CaravanDto caravanDto);
    public Task DeleteAsync(Guid Id);
}

