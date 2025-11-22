using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nusuk.Backend.API.Dtos.Otp;
using Nusuk.Services.AuthServices.Helper;
using Nusuk.Services.AuthServices.Service;
using Nusuk.Services.AuthServices.Services;
using Nusuk.Services.Otp;

namespace Nusuk.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService _authService, IOtpService _otpService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<AuthModel>> RegisterAsync(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authService.RegisterAsync(model);

        if (!result.IsAuthenticated)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<ActionResult<AuthModel>> LogInAsync(LogInModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authService.LogInAsync(model);

        if (!result.IsAuthenticated)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
    [HttpPost("register/sendotp")]
    public async Task<IActionResult> SendOtpAsync(OtpRequestModel model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _otpService.SendOtpAsync(model.Email);

        if (result is null)
        {
            return BadRequest($"Faild to Send OTP to{model.Email}");
        }

        return Ok(result);
    }

    [HttpPost("register/verfiy")]
    public async Task<IActionResult> VerfiyOtpAsync(VerfiyOtpModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _otpService.VerfiyCodeAsync(model.Email,model.Code);

        if (!result)
        {
            return BadRequest($"Invalid Code");
        }

        return Ok(result);
    }

    [HttpPost("changepassword")]
    public async Task<IActionResult> ChagePasswordAsync(ChangePasswordModel model)
    {

        var result = await _otpService.ChangePasswordAsync(model.Email, model.Password);

        if (!result)
        {
            return BadRequest("Failed to change password");
        }

        return Ok(result);
    }
}
