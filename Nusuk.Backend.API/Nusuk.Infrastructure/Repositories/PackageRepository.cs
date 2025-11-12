using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class PackageRepository(NusukDbContext _context) : BaseRepository<Package>(_context),IPackageRepository
{
}
