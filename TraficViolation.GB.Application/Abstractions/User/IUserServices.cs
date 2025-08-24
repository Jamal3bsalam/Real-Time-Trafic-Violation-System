using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Contracts.User;

namespace TraficViolation.GB.Application.Abstractions.User
{
    public interface IUserServices
    {
        Task<UserDto> LogInAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailExistAsync(string email);
        Task<string> OtpRequest(ForgetPassDto forgetPassDto);
        Task<string> OtpVerificationn(string email, string Otp);
        Task<string> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
