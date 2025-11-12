using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class ServiceDetailRepository(NusukDbContext _context) : BaseRepository<ServiceDetail>(_context), IServiceDetailRepository
{
}

