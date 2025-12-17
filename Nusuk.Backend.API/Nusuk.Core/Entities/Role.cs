using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class Role : BaseEntity
{
    public string? Name { get; set; }
    public List<User> Users { get; set; }
    public List<Booking> Bookings { get; set; }

}
