using System.ComponentModel.DataAnnotations;

namespace Nusuk.Backend.API.Dtos.Otp;

public class VerfiyOtpModel
{
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(50)]
    public required string Email { get; set; }
    [MaxLength(6)]
    public required string Code { get; set; }
}
