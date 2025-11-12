using Nusuk.Core.Common;
using Nusuk.Core.Enums;

namespace Nusuk.Core.Entities;

public class Trip:BaseEntity
{
    public string? Name {  get; set; }
    public string? Description { get; set; }
    public TripType Type {  get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TripPackage TripPackages { get; set; } = null!;



}
