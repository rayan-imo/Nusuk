using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class RoleRepository(NusukDbContext _context) : BaseRepository<Role>(_context), IRoleRepository
{
}


