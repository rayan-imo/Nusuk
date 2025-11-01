using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories
{
    public class UserRepository(NusukDbContext _context) : BaseRepository<User>(_context), IUserRepository
    {
    }
}
