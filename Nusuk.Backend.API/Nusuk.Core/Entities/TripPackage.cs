using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class TripPackage : BaseEntity
{
    public List<Package> Packages { get; set; }
    public List<Trip> Trips { get; set; }
    public Caravan? Caravan { get; set; }
    public Guid Carvan {  get; set; }


}
