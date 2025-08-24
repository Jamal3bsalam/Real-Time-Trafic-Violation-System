using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraficViolation.GB.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string recipientEmail, string subject, string body);

    }
}
