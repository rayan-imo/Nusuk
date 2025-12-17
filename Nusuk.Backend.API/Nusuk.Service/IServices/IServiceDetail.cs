using Nusuk.Core.Entities;

namespace Nusuk.Services.IServices;

public interface IServiceDetail
{
    public Task<Guid> AddServiceToPackage(Guid serviceId, Guid packageId);
    public Task<Guid> RemoveServiceFromPackage(Guid serviceId, Guid packageId);
    public Task<IEnumerable<Package>> GetServiceByPackageId(Guid packageId);
}
