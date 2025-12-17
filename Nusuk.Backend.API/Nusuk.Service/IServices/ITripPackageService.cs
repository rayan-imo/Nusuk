using Nusuk.Core.Entities;

namespace Nusuk.Services.IServices;

public interface ITripPackageService
{
    public Task<Guid> AddPackageToTrip(Guid tripId, Guid packageId);
    public Task<Guid> RemovePackageFromTrip(Guid tripId, Guid packageId);
    public Task<IEnumerable<Package>> GetPackageByTripId(Guid tripId);
}