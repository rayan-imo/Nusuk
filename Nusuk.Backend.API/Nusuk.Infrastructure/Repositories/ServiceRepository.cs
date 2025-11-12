using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class ServiceRepository(NusukDbContext _context) : BaseRepository<Service>(_context), IServiceRepository
{
}


