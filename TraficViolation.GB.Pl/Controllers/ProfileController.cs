using FurnitureApp.PL.Response.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TraficViolation.GB.Application.Abstractions.Profile;
using TraficViolation.GB.Application.Contracts.Profile;
using TraficViolation.GB.Application.Contracts.User;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Infrastructure.Data.Context;

namespace TraficViolation.GB.Pl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProfileService _profileService;
        private readonly TraficViolationDbContext _context;
        private readonly IConfiguration _configuration;

        public ProfileController(UserManager<AppUser> userManager, IProfileService profileService, TraficViolationDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _profileService = profileService;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("user")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) return BadRequest(new ErrorResponse(400));

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest(new ErrorResponse(400));
            return Ok(new CurrentUsetDto()
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                ProfilePicture = _configuration["BASEURL"] + user.ProfileImageUrl
            }); 
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateProfiel(UpdateProfileDto updateProfileDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _profileService.Update(updateProfileDto);
            if (result == 0) return BadRequest(new ErrorResponse(401));
            return Ok(new { message = "Profile Updated Successfully" });
        }

        [HttpPost("UploadProfileImage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UploadProfileImage(ProfileImageDto profileImageDto)
        {
            if (profileImageDto.File == null || profileImageDto.File.Length == 0) return BadRequest("No File Uploaded");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized(new ErrorResponse(401));

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return BadRequest(new ErrorResponse(400));

            if (!string.IsNullOrEmpty(user.ProfileImageUrl)) return BadRequest(new ErrorResponse(400));
            string file = _profileService.Upload(profileImageDto);
            if (file == null) return BadRequest(new ErrorResponse(400));

            user.ProfileImageUrl = $"Images\\ProfileImage\\{file}";
            await _userManager.UpdateAsync(user);

            return Ok(new { Message = "Image uploaded successfully" });
        }

        [HttpDelete("DeleteProfileImage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteProfileImage()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized(new ErrorResponse(401));

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound(new ErrorResponse(404));

            if (string.IsNullOrEmpty(user.ProfileImageUrl)) return BadRequest(new ErrorResponse(400, "No Image Profile"));
            _profileService.Delete(user.ProfileImageUrl);

            user.ProfileImageUrl = null;
            await _userManager.UpdateAsync(user);

            return Ok(new { Message = "Image Deleted successfully" });
        }

        [HttpPut("UpdateProfileImage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateProfileImage(ProfileImageDto profileImageDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized(new ErrorResponse(401));

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound(new ErrorResponse(404));

            if (!string.IsNullOrEmpty(user.ProfileImageUrl))
            {
                _profileService.Delete(user.ProfileImageUrl);
            }

            string file = _profileService.Upload(profileImageDto);
            if (file == null) return BadRequest(new ErrorResponse(400));

            user.ProfileImageUrl = $"Images\\ProfileImage\\{file}";
            await _userManager.UpdateAsync(user);

            return Ok(new { Message = "Image Updated successfully" });
        }
    }
}
