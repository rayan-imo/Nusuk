using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;

public interface IServiceService
{
    public Task<IEnumerable<Service>> GetAllAsync();
    public Task<Service> GetByIdAsync(Guid id);
    public Task<Guid> AddAsync(ServiceDto serviceDto);
    public Task<Guid> UpdateAsync(Guid Id, ServiceDto servicedto);
    public Task DeleteAsync(Guid Id);
}
