using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class ServiceDetail:BaseEntity
{
    public string? Name {  get; set; }
    public string? Description { get; set; }
    public decimal Price {  get; set; }
    public Service? Service { get; set; } 
    public Guid ServiceId { get; set; }
    public Package? Package{ get; set; }
    public Guid PackageId {  get; set; }

}
