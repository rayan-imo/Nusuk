using Microsoft.Extensions.Configuration;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;
using Nusuk.Infrastructure.Repositories;

namespace Nusuk.Infrastructure;

public class UnitOfWork(NusukDbContext _context) : IUnitOfWork
{
    private IUserRepository _userRepository;
    private IBookingRepository _bookingRepository;
    private ICaravanRepository _caravanRepository;
    public IPackageRepository _packageRepository;
    public IRoleRepository _roleRepository;
    public IServiceRepository _serviceRepository;
    public IServiceDetailRepository _serviceDetailRepository;
    public ITripRepository _tripRepository;
    public ITripPackageRepository _tripPackageRepository;
    public IUserServiceRepository _userServiceRepository;
    public IUserOtpRepository _userOtpRepository;
    public IUserRepository UsersRepository => new UserRepository(_context);
    public IBookingRepository BookingRepository=>new BookingRepository(_context);
    public ICaravanRepository CaravanRepository=>new CaravanRepository(_context);
    public IPackageRepository PackageRepository =>new PackageRepository(_context);
    public IRoleRepository RoleRepository=>new RoleRepository(_context);
    public IServiceRepository ServiceRepository =>new ServiceRepository(_context);

    public IServiceDetailRepository ServiceDetailRepository=new ServiceDetailRepository(_context);
    public ITripRepository TripRepository=>new TripRepository(_context);    
    public ITripPackageRepository TripPackageRepository =>new TripPackageRepository(_context);
    public IUserServiceRepository UserServiceRepository =>new UserServiceRepository(_context);
    public IUserOtpRepository UserOtpRepository => new UserOtpRepository(_context);



    public int Complete()
    {
        return _context.SaveChanges();
    }
    public Task<int> CompleteAsync()
    {
        return _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
