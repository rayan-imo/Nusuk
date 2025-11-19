using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.IServices;

namespace Nusuk.Services.Services;

public class UserService(IUnitOfWork _uow) : IUserService
{
    public async Task <IEnumerable<User>> GetAllAsync()
    {
        return await _uow.UsersRepository.GetAllAsync();
    }


    public async Task<User> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid user ID.", nameof(id));
           

        var user = await _uow.UsersRepository.GetByIdAsync(id);

        if (user == null)
             throw new KeyNotFoundException($"User with ID '{id}' was not found.");
        
        return user;
    }
}
