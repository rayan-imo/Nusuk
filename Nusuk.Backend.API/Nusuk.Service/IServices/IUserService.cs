using Nusuk.Core.Entities;

namespace Nusuk.Services.IServices;

public interface IUserService
{
    public Task<IEnumerable<User>>GetAllAsync();
    public Task<User> GetByIdAsync(Guid id);

}
