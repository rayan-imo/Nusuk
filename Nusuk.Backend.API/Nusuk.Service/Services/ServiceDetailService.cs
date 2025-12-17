using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.IServices;

namespace Nusuk.Services.Services;

public class ServiceDetailService(IUnitOfWork _uow):IServiceDetail
{
    public async Task<Guid> AddServiceToPackage(Guid serviceId, Guid packageId)
    {
        var service = await _uow.ServiceRepository.GetByIdAsync(serviceId);
        if (service == null)
        {
            throw new Exception("Service not found");
        }
        var package = await _uow.PackageRepository.GetByIdAsync(packageId);
        if (package == null)
        {
            throw new Exception("Package not found");
        }
        var result = await _uow.ServiceDetailRepository.FindAsync(x => x.ServiceId == serviceId && x.PackageId == packageId);
        if (result is not null)
        {
            throw new Exception("This service is already assigned to this package");
        }
        var serviceDetail = new ServiceDetail()
        {
            ServiceId=serviceId,
            PackageId = packageId
        };
        await _uow.ServiceDetailRepository.AddAsync(serviceDetail);
        await _uow.CompleteAsync();
        return serviceDetail.Id;
    }

    public async Task<Guid> RemoveServiceFromPackage(Guid serviceId, Guid packageId)
    {
        var service = await _uow.ServiceDetailRepository.GetByIdAsync(serviceId);
        if (service == null)
        {
            throw new Exception("Service not found");
        }
        var package = await _uow.PackageRepository.GetByIdAsync(packageId);
        if (package == null)
        {
            throw new Exception("Package not found");
        }
        var serviceDetail = await _uow.ServiceDetailRepository.GetByItemAsync(x => x.ServiceId == serviceId && x.PackageId == packageId);
        if (serviceDetail is null)
        {
            throw new Exception("Service not found in this package");
        }
        await _uow.ServiceDetailRepository.DeleteAsync(serviceDetail);
        await _uow.CompleteAsync();
        return serviceDetail.Id;
    }
    public async Task<IEnumerable<Package>> GetServiceByPackageId(Guid serviceId)
    {
        var service = await _uow.ServiceRepository.GetByIdWithAllIncludes(serviceId);
        if (service is null)
        {
            throw new Exception("service not found");
        }

        var package = service.ServiceDetails.Select(x => x.Package!).ToList();
        return package;

    }
}

