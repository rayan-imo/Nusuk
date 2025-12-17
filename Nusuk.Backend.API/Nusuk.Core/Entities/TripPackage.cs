using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class TripPackage : BaseEntity
{
    public Package? Package { get; set; }
    public Trip? Trip { get; set; }
    public List<Caravan> Caravan { get; set; }
    public Guid TripId {  get; set; }
    public Guid PackageId {  get; set; }


}
