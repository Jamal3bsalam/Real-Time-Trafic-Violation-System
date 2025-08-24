using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Contracts.User;

namespace TraficViolation.GB.Application.Abstractions.Otp
{
    public interface IOtpService
    {
        Task<string> OtpGenerateAsync(ForgetPassDto forgetPassDto);
        Task<bool> OtpValidation(string email, string Otp);
    }
}
