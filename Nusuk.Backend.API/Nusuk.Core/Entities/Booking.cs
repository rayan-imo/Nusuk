using Nusuk.Core.Common;
using Nusuk.Core.Enums;

namespace Nusuk.Core.Entities;

public class Booking: BaseEntity
{
     public decimal Price {  get; set; }
    public AmountMethod AmountMethod { get; set; }
    public bool IsPaid {  get; set; }
    public User? User { get; set; }
    public Guid UserId {  get; set; }
    public Caravan? Caravan { get; set; }
    public Guid CaravanId {  get; set; }
    public Role? Role { get; set; }
    public Guid? RoleId { get; set; }
   
   
}
