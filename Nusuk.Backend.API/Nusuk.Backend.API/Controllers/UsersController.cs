using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Users.Responses;
using Nusuk.Core.Common.Pagination;
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
        public async Task<ActionResult<UserResponse>> GetAll([FromQuery] PaginationParameter pagination)
        {
            var result = await _userService.GetAllAsync(pagination);
            if (result is null || !result.Items.Any())
            {
                return NotFound($"No users found");
            }

            return Ok(result?.Items.Select(UserResponse.Transform));
        }
        [HttpGet("id")]
        public async Task<ActionResult<UserResponse>> GetByIdAsync(Guid id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result is null || id == Guid.Empty)
            {
                return NotFound($"User with ID {id} not found");
            }
            return UserResponse.Transform(result);
        }
        [HttpPost]
        public async Task<ActionResult<UserResponse>> AddAsync(UserDto userdto)
        {  await new UserValidator().ValidateAndThrowAsync(userdto);
            var userId = await _userService.AddAsync(userdto);
            return Ok(userId);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateAsync(Guid id, UserDto userdto)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound("User not found");


            await new UserValidator().ValidateAndThrowAsync(userdto);
            var userId = await _userService.UpdateAsync(id, userdto);
            return Ok(userId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid ID");

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound("User not found");

            await _userService.DeleteAsync(id);
            return Ok();

        }
    }
}
