using Nusuk.Core.Common;

namespace Nusuk.Core.Entities;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public  string? LastName { get; set; }
    public string? Email { get; set; }
    public  string? Password { get; set; }
    public string? Phone {  get; set; }
    public string? NationalId {  get; set; }
    public string? Nationality { get; set; }
    public string? Gendre {  get; set; }
    public DateTime? DateOfBrith { get; set; }
    public UserServiceInfo UserService { get; set; }
    public Booking Booking { get; set; }
    public List<Role> Roles { get; set; }




}
