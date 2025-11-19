using Nusuk.Core.Common;

namespace Nusuk.Services.Otp;

public class UserOtp:BaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Email {  get; set; }

    public string Code { get; set;}
    public bool IsUSed {  get; set; }
    public DateTime ExpireDate {  get; set; }

}
