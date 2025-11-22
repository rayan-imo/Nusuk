using System.ComponentModel.DataAnnotations;

namespace Nusuk.Backend.API.Dtos.Otp;

public class ChangePasswordModel
{
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(50)]
    public required string Email { get; set; }

    [MaxLength(50)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
           ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
    public required string Password { set; get; }
}
