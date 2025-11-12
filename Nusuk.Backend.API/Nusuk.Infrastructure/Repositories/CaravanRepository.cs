using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class CaravanRepository(NusukDbContext _context) : BaseRepository<Caravan>(_context),ICaravanRepository
{
}
