using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class ServiceDetail:BaseEntity
{
    public string? Name {  get; set; }
    public string? Description { get; set; }
    public decimal Price {  get; set; }
    public List<Service> Services { get; set; } 
    public List<Trip> Journies { get; set; }
}
