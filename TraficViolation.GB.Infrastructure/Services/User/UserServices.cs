using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Abstractions.Email;
using TraficViolation.GB.Application.Abstractions.Otp;
using TraficViolation.GB.Application.Abstractions.Token;
using TraficViolation.GB.Application.Abstractions.UnitOfWork;
using TraficViolation.GB.Application.Abstractions.User;
using TraficViolation.GB.Application.Contracts.User;
using TraficViolation.GB.Domain.Entities;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Infrastructure.Services.Token;

namespace TraficViolation.GB.Infrastructure.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly ITokenServices _tokenServices;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IOtpService _otpService;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(ITokenServices tokenServices , UserManager<AppUser> userManager, SignInManager<AppUser>signInManager,IOtpService otpService,IEmailService emailService,IUnitOfWork unitOfWork)
        {
            _tokenServices = tokenServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _otpService = otpService;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await CheckEmailExistAsync(registerDto.Email)) return null;

            var user = new AppUser()
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.PhoneNumber,
            };

            var vehicleOwner = new VehicleOwner()
            {
                FullName = registerDto.FullName,
                NationalId = registerDto.NationalId,
                CarPlateNumber = registerDto.VehiclePlateNumber,
                VehicleType = registerDto.VehicleType,
                Licensenumber = registerDto.Licensenumber,
                UserId = user.Id,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, "VehicleOwner");
            if (!result.Succeeded) return null;

            await _unitOfWork.Repository<VehicleOwner,int>().AddAsync(vehicleOwner);
            await _unitOfWork.CompleteAsync();

            return new UserDto()
            {
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                Token = await _tokenServices.CreateTokenAsync(user, _userManager)
            };
        }


        public async Task<UserDto> LogInAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) return null; // Not Found
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return null;

            return new UserDto()
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenServices.CreateTokenAsync(user, _userManager)
            };
        }

        public async Task<string> OtpRequest(ForgetPassDto forgetPassDto)
        {

            var otp = await _otpService.OtpGenerateAsync(forgetPassDto);
            var result = await _emailService.SendEmailAsync(forgetPassDto.Email, "Reset Password OTP", $"Your Reset Passord OTP Is : {otp}");
            if (result is null) return null;

            return "Your OTP Send Succefully";
        }

        public async Task<string> OtpVerificationn(string email, string Otp)
        {
            bool isValid = await _otpService.OtpValidation(email, Otp);
            if (!isValid) return "Invalid or expired OTP";
            return "OTP verified successfully.";
        }

        public async Task<string> ResetPassword(ResetPasswordDto resetPasswordDto)
        {

            if (resetPasswordDto.Email == null || resetPasswordDto.Email == null || resetPasswordDto.Password == null || resetPasswordDto.Otp == null) return null;

            bool isValid = await _otpService.OtpValidation(resetPasswordDto.Email, resetPasswordDto.Otp);
            if (!isValid) return null;

            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user is null) return null;

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (string.IsNullOrEmpty(resetToken)) return null;

            var result = await _userManager.ResetPasswordAsync(user, resetToken, resetPasswordDto.Password);

            return result.Succeeded ? "Password has been reset successfully." : "Password reset failed.";
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
