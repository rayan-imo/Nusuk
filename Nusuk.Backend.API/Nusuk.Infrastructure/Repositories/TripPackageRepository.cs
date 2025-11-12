using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class TripPackageRepository(NusukDbContext _context) : BaseRepository<TripPackage>(_context), ITripPackageRepository
{
}

