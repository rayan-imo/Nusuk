using Nusuk.Core.Entities;

namespace Nusuk.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{

    IUserRepository UsersRepository { get; }
    IBookingRepository BookingRepository {  get; }
    ICaravanRepository CaravanRepository {  get; }
    IPackageRepository PackageRepository {  get; }
    IRoleRepository RoleRepository {  get; }
    IServiceRepository ServiceRepository {  get; }
    ITripRepository TripRepository {  get; }
    ITripPackageRepository TripPackageRepository {  get; }
    IUserServiceRepository UserServiceRepository {  get; }
    IUserOtpRepository UserOtpRepository { get; }



    int Complete();
    public Task<int> CompleteAsync();

}
