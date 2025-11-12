using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class TripRepository(NusukDbContext _context) : BaseRepository<Trip>(_context), ITripRepository
{
}

