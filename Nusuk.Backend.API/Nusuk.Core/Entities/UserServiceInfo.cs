using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class UserServiceInfo: BaseEntity
{
    public decimal Price {  get; set; }
    public List<UserServiceInfo> UserServices {  get; set; }
    public List<Service> Services { get; set; }
}
