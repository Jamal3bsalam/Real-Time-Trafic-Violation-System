using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Abstractions.Profile;
using TraficViolation.GB.Application.Contracts.Profile;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Infrastructure.Data.Context;

namespace TraficViolation.GB.Infrastructure.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly TraficViolationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProfileService(TraficViolationDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<int> Update(UpdateProfileDto updateProfileDto)
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            if (userId == null) return 0;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return 0;
            if(updateProfileDto.FullName is not null)
            user.FullName = updateProfileDto.FullName;
            if (updateProfileDto.FullName is not null)
            user.PhoneNumber = updateProfileDto.PhoneNumber;
            if (updateProfileDto.Email is not null)
            user.Email = updateProfileDto.Email;
            _context.Update(user);
            var resutl = await _context.SaveChangesAsync();
            return resutl;
        }
  
        public string Upload(ProfileImageDto profileImageDto)
        {
            //D:\Real-Time Trafic Violation Logger\TraficViolation.GB.Pl\wwwroot\Images\ProfileImage\
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string folderPath = (CurrentDirectory + $"\\wwwroot\\Images\\ProfileImage");

            string fileName = profileImageDto.File.FileName;

            string filePath = Path.Combine(folderPath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            profileImageDto.File.CopyTo(fileStream);

            return fileName;
        }
        public void Delete(string fileName)
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string filePath = (CurrentDirectory + $"\\wwwroot\\{fileName}");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
