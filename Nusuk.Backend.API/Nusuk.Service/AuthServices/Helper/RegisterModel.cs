using Nusuk.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Nusuk.Services.AuthServices.Helper;

public class RegisterModel
{
    [MaxLength(20)]
    public required string Name {  get; set; }
   // [MaxLength(20)]
 //   public required string LastName { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(50)]
    public required string Email { get; set; }

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
           ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
    public required string Password { get; set; }
    [Required]
    public Role Role{ get; set; }


}
