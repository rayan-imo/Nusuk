using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class UserServiceInfo: BaseEntity
{
    public decimal Price {  get; set; }
    public User User {  get; set; }
    public Service Services { get; set; }
    public Guid ServiceId {  get; set; }
    public Guid UserId { get; set; }
}
