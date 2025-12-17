using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class Service:BaseEntity
{
    public string? Name {  get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public bool? IsIncluded { get; set; }
    public string? ProviderName {  get; set; }
    public List<ServiceDetail> ServiceDetails { get; set; }
    public List< UserServiceInfo> UserService { get; set; }
}
