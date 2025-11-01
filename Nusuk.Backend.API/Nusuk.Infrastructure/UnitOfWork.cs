using Microsoft.Extensions.Configuration;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;
using Nusuk.Infrastructure.Repositories;

namespace Nusuk.Infrastructure;

public class UnitOfWork(NusukDbContext _context) : IUnitOfWork
{
    private IUserRepository _userRepository;

    public IUserRepository UsersRepository => new UserRepository(_context);

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
