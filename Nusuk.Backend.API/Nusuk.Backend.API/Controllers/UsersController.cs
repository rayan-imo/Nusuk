using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Users.Responses;
using Nusuk.Services.Dtos;
using Nusuk.Services.IServices;
using Nusuk.Services.Otp;
using Nusuk.Services.Validators.User;

namespace Nusuk.ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetAllUser()
        {
            var result = await _userService.GetAllAsync();
            if (result is null || !result.Any())
            {
                return NotFound($"No users found");
            }

            return Ok(result?.Select(UserResponse.Transform));
        }
        [HttpGet("userId")]
        public async Task<ActionResult<UserResponse>> GetByIdAsync(Guid Id)
        {
            var result = await _userService.GetByIdAsync(Id);
            if (result is null || Id == Guid.Empty)
            {
                return NotFound($"User with ID {Id} not found");
            }
            return UserResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<UserResponse>> AddAsync(UserDto userdto)
        {  await new UserValidator().ValidateAndThrowAsync(userdto);
            var userId = await _userService.AddAsync(userdto);
            return Ok(userId);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<UserResponse>> UpdateAsync(Guid Id, UserDto userdto)
        {
            if (Id == Guid.Empty)
                return BadRequest("Invalid ID");

            var user = await _userService.GetByIdAsync(Id);
            if (user == null)
                return NotFound("User not found");


            await new UserValidator().ValidateAndThrowAsync(userdto);
            var userId = await _userService.UpdateAsync(Id, userdto);
            return Ok(userId);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            if (Id == Guid.Empty)
                return BadRequest("Invalid ID");

            var user = await _userService.GetByIdAsync(Id);
            if (user == null)
                return NotFound("User not found");

            await _userService.DeleteAsync(Id);
            return Ok();

        }
    }
}
