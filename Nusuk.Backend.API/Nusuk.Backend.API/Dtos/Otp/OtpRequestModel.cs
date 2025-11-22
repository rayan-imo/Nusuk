using System.ComponentModel.DataAnnotations;

namespace Nusuk.Backend.API.Dtos.Otp;

public class OtpRequestModel
{

    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(50)]
    public required string Email { get; set; }

}
