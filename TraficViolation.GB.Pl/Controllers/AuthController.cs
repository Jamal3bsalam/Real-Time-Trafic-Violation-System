using FurnitureApp.PL.Response.Error;
using FurnitureApp.PL.Response.GeneralResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraficViolation.GB.Application.Abstractions.User;
using TraficViolation.GB.Application.Contracts.User;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Infrastructure.Services.User;
using static System.Net.WebRequestMethods;

namespace TraficViolation.GB.Pl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IUserServices userServices,UserManager<AppUser> userManager)
        {
            _userServices = userServices;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<UserDto>>> LogIn(LoginDto loginDto)
        {
            var user = await _userServices.LogInAsync(loginDto);
            if (user == null) return BadRequest(new ErrorResponse(400));
            return Ok(new ApiResponse<UserDto>(true,200, "User logged in successfully",user));
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<UserDto>>> Register(RegisterDto registerDto)
        {
            if(!ModelState.IsValid) return BadRequest(new ErrorResponse(400));
            var user = await _userServices.RegisterAsync(registerDto);
            if (user == null) return BadRequest(new ErrorResponse(400));
            return Ok(new ApiResponse<UserDto>(true, 200, "Registration completed successfully", user));
        }
        [HttpPost("forgetPassword")]
        public async Task<ActionResult<ApiResponse<string>>> ForgetPassword(ForgetPassDto forgetPassDto)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassDto.Email);
            if (user == null) return BadRequest(new ErrorResponse(400));
            var otp = await _userServices.OtpRequest(forgetPassDto);
            return Ok(new ApiResponse<string>(true,200,"",otp));
        }
        [HttpPost("otpVerification")]
        public async Task<ActionResult<ApiResponse<string>>> OTPVerification(string email, string Otp)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest(new ErrorResponse(400));
            var result = await _userServices.OtpVerificationn(email, Otp);
            return Ok(new ApiResponse<string>(true, 200, "", result));
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult<ApiResponse<string>>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if(resetPasswordDto.Email == null) return BadRequest(new ErrorResponse(400));
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null) return BadRequest(new ErrorResponse(400));
            var result = await _userServices.ResetPassword(resetPasswordDto);
            if (result is null) return BadRequest(new ErrorResponse(400));
            return Ok(new ApiResponse<string>(true, 200, "Success", result));
        }
    }
}
