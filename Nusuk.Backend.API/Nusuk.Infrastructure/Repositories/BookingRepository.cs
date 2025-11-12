using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class BookingRepository(NusukDbContext _context) : BaseRepository<Booking>(_context), IBookingRepository
{
}

