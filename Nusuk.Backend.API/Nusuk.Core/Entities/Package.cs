using Nusuk.Core.Common;
using Nusuk.Core.Enums;

namespace Nusuk.Core.Entities;

public class Package:BaseEntity
{
    public string? Name {  get; set; }
    public string? Descrption { get; set; }
    public decimal? TotalPrice { get; set; }
    public PackageLevel Level { get; set; }
    public bool IsActive {  get; set; }
    public TripPackage JournyPackage { get; set; } = null!;
    public Service ServiceDetail { get; set; } = null!;

}
