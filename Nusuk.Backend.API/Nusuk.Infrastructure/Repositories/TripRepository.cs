using Microsoft.EntityFrameworkCore;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure.Repositories;

public class TripRepository(NusukDbContext _context) : BaseRepository<Trip>(_context), ITripRepository
{
    public async Task<IEnumerable<object>> GetTripsWithDetailsAsync()
    {
        return await _context.Trips
            .Where(t => t.DeletedAt == null)
            .Select(t => new
            {
                t.Id,
                t.Name,
                t.Description,

                Packages = t.TripPackages
                    .Select(tp => new
                    {
                        PackageId = tp.Package.Id,
                        PackageName = tp.Package.Name,
                        tp.Package.TotalPrice,

                        Services = tp.Package.ServiceDetail
                            .Select(sd => new
                            {
                                ServiceId = sd.Service.Id,
                                ServiceName = sd.Service.Name,
                                sd.Service.Description
                            })
                    })
            })
            .ToListAsync();
    }
}

