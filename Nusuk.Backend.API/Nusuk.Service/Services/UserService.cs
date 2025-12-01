using FluentValidation;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Otp;
using Nusuk.Services.Validators.User;

namespace Nusuk.Services.Services;

public class UserService(IUnitOfWork _uow) : IUserService
{
    public async Task <IEnumerable<User>> GetAllAsync()
    {
        var users = await _uow.UsersRepository.GetAllAsync();
        return users.Where(u => u.DeletedAt == null);

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
    public async Task<Guid>AddAsync(UserDto userdto)
    {
        await new UserValidator().ValidateAndThrowAsync(userdto);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = userdto.UserName,
            Email = userdto.Email,
            Password = userdto.Password,
            Phone = userdto.Phone,
            RoleId = userdto.RoleId
        };
        await _uow.UsersRepository.AddAsync(user);
        await _uow.CompleteAsync();
        return user.Id;
    }
    public async Task<Guid>UpdateAsync(Guid Id,UserDto userdto)
    {
        var user = await _uow.UsersRepository.GetByIdAsync(Id);
        if (user is null)
        {
            throw new KeyNotFoundException("User not found");
        }
        await new UserValidator().ValidateAndThrowAsync(userdto);
        user.Name=userdto.UserName;
        user.Email=userdto.Email;
        user.Password=userdto.Password;
        user.Phone=userdto.Phone;

        await _uow.UsersRepository.UpdateAsync(user);
        await _uow.CompleteAsync();
        return user.Id;
    }
    public async Task  DeleteAsync(Guid Id)
    { var user = await _uow.UsersRepository.GetByIdAsync(Id);
        if (user is null)
        {
            throw new KeyNotFoundException("User not found");
        }
        await _uow.UsersRepository.DeleteAsync(user);
        await _uow.CompleteAsync();
    }
}
