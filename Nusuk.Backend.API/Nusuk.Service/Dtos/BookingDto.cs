using Nusuk.Core.Entities;
using Nusuk.Core.Enums;

namespace Nusuk.Services.Dtos
{
    public class BookingDto
    {
        public decimal Price { get; set; }
     //  public AmountMethod AmountMethod { get; set; }
      //  public bool IsPaid { get; set; }
        public Guid UserId { get; set; }
        public Guid CaravanId { get; set; }
        public Guid? RoleId { get; set; }
    }
}
