using Nusuk.Core.Entities;

namespace Nusuk.Backend.API.Dtos.Users.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
       public Guid? RoleId { get; set; }
        public required string  Name { get; set; }
        public string? Phone { get; set; }
        public static UserResponse Transform(User user)
        {
            return new UserResponse()
            {
                Id = user.Id,
                Email = user.Email,
                RoleId = user.RoleId,
                Name = user.Name,
                Phone = user.Phone
            };
        }
    }
     
                
}
