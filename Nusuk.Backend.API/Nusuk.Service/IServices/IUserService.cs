using Nusuk.Core.Entities;

namespace Nusuk.Service.IServices;

public interface IUserService
{
    public Task<IEnumerable<User>>GetAllAsync();
    public Task<User> GetByIdAsync(Guid id);

}
