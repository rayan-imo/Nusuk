using Nusuk.Core.Common.Pagination;
using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;

public interface IServiceService
{
    public Task<PagedResult<Service>> GetAllAsync(PaginationParameter pagination);
    public Task<Service> GetByIdAsync(Guid id);
    public Task<Guid> AddAsync(ServiceDto serviceDto);
    public Task<Guid> UpdateAsync(Guid Id, ServiceDto servicedto);
    public Task DeleteAsync(Guid Id);
}
