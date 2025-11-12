using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class UserServiceRepository(NusukDbContext _context) : BaseRepository<UserServiceInfo>(_context),IUserServiceRepository
{
}

