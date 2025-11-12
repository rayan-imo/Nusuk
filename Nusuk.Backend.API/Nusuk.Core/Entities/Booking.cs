using Nusuk.Core.Common;
using Nusuk.Core.Enums;

namespace Nusuk.Core.Entities;

public class Booking:BaseEntity
{
     public decimal TotalAmount {  get; set; }
    public AmountMethod AmountMethod { get; set; }
    public bool IsPaid {  get; set; }
    public List<User> User { get; set; }
    public Guid UserId {  get; set; }
    public List<Caravan> Caravan { get; set; }
    public Guid CaravanId {  get; set; }
    public List<Role> Role { get; set; }

}
