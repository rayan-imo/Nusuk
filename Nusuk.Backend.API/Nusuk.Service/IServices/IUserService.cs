using Nusuk.Core.Entities;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.IServices;

public interface IUserService
{
    public Task<IEnumerable<User>>GetAllAsync();
    public Task<User> GetByIdAsync(Guid id);
    public Task<Guid> AddAsync(UserDto userdto);
    public Task<Guid> UpdateAsync(Guid Id,UserDto userdto);
    public Task DeleteAsync(Guid Id);
}