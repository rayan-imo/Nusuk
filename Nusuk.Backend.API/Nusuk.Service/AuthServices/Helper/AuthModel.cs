namespace Nusuk.Services.AuthServices.Helper;

public class AuthModel
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Name { get; set; }
   // public string LastName { get; set; }
    public string Email { get; set; }
    public Guid RoleId{ get; set; }
    public string Token { get; set; }
    public DateTime ExpiresOn { get; set; }
}
