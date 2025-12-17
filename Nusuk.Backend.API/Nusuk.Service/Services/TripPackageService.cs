using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.IServices;

namespace Nusuk.Services.Services;

public class TripPackageService(IUnitOfWork _uow) : ITripPackageService
{
    public async Task<Guid> AddPackageToTrip(Guid tripId, Guid packageId)
    {
        var trip = await _uow.TripRepository.GetByIdAsync(tripId);
        if (trip == null)
        {
            throw new Exception("Trip not found");
        }
        var package = await _uow.PackageRepository.GetByIdAsync(packageId);
        if (package == null)
        {
            throw new Exception("Package not found");
        }
        var result = await _uow.TripPackageRepository.FindAsync(x => x.TripId == tripId && x.PackageId == packageId);
        if (result is not null)
        {
            throw new Exception("This package is already assigned to this trip");
        }
        var tripPackage = new TripPackage()
        {
            TripId = tripId,
            PackageId = packageId
        };
        await _uow.TripPackageRepository.AddAsync(tripPackage);
        await _uow.CompleteAsync();
        return tripPackage.Id;
    }
    public async  Task<Guid> RemovePackageFromTrip(Guid tripId, Guid packageId)
    {
        var trip = await _uow.TripRepository.GetByIdAsync(tripId);
        if (trip == null)
        {
            throw new Exception("Trip not found");
        }
        var package = await _uow.PackageRepository.GetByIdAsync(packageId);
        if (package == null)
        {
            throw new Exception("Package not found");
        }
        var tripPackage = await _uow.TripPackageRepository.GetByItemAsync(x => x.TripId == tripId && x.PackageId == packageId);
        if (tripPackage is null)
        {
            throw new Exception("Package not found in this trip");
        }
        await _uow.TripPackageRepository.DeleteAsync(tripPackage);
        await _uow.CompleteAsync();
        return tripPackage.Id;
    }
    public async Task<IEnumerable<Package>> GetPackageByTripId(Guid tripId)
    {
        var trip = await  _uow.TripRepository.GetByIdWithAllIncludes(tripId);
        if (trip is null)
        {
            throw new Exception("Trip not found");
        }
        
        var package= trip.TripPackages.Select(x => x.Package!).ToList();
        return package;

      
    }
}
