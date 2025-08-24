﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Abstractions.Email;
using TraficViolation.GB.Domain.Shared.EmailConfig;

namespace TraficViolation.GB.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(IOptions<EmailConfiguration> emailConfig, IConfiguration configuration)
        {
            _emailConfig = emailConfig.Value;
            Console.WriteLine($"Host: {_emailConfig.Host}");
            Console.WriteLine($"Port: {_emailConfig.Port}");
            Console.WriteLine($"UserName: {_emailConfig.UserName}");
            Console.WriteLine($"Password: {_emailConfig.Password}");
        }
        public async Task<string> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_emailConfig.UserName, "Traffic Violation System Application"),
                    To = { new MailAddress(recipientEmail) },
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                using (var smtp = new SmtpClient(_emailConfig.Host, _emailConfig.Port))
                {
                    smtp.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
                return "Email sent successfully.";
            }
            catch (Exception ex)
            {
                return $"Failed to send email: {ex.Message}";
            }

        }
    }
}
