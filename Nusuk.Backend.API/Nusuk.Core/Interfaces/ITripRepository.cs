using Nusuk.Core.Entities;

namespace Nusuk.Core.Interfaces;

public interface ITripRepository : IBaseRepository<Trip>
{
    public Task<IEnumerable<object>> GetTripsWithDetailsAsync();


}
