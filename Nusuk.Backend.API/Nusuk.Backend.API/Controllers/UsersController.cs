using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Core.Entities;
using Nusuk.Service.IServices;
using Nusuk.Service.Services;

namespace Nusuk.ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController (IUserService _userService): ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUser()
        {
           return await _userService.GetAllAsync();
        }
        [HttpGet("userId")]
        public async Task<User> GetUserById(Guid Id)
        {
            return await _userService.GetByIdAsync(Id);
        }

    }
}
