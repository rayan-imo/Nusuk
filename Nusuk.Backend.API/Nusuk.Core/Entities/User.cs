using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class User : BaseEntity
{
    public string? Name { get; set; }
  //  public  string? LastName { get; set; }
    public string? Email { get; set; }
    public  string? Password { get; set; }
    public string? Phone {  get; set; }
    public string? NationalId {  get; set; }
    public string? Nationality { get; set; }
    public string? Gendre {  get; set; }
    public DateTime? DateOfBrith { get; set; }
    public List<UserServiceInfo?> UserService { get; set; }
    public List<Booking> Booking { get; set; }
    public Role? Role { get; set; }
    public Guid? RoleId { get; set; }

}
