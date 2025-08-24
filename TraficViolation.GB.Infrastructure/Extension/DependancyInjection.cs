using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Abstractions.Email;
using TraficViolation.GB.Application.Abstractions.Otp;
using TraficViolation.GB.Application.Abstractions.Profile;
using TraficViolation.GB.Application.Abstractions.Token;
using TraficViolation.GB.Application.Abstractions.UnitOfWork;
using TraficViolation.GB.Application.Abstractions.User;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Infrastructure.Data;
using TraficViolation.GB.Infrastructure.Data.Context;
using TraficViolation.GB.Infrastructure.Services.Email;
using TraficViolation.GB.Infrastructure.Services.Otp;
using TraficViolation.GB.Infrastructure.Services.Profile;
using TraficViolation.GB.Infrastructure.Services.Token;
using TraficViolation.GB.Infrastructure.Services.User;

namespace TraficViolation.GB.Infrastructure.Extension
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddDependancies(this IServiceCollection services , IConfiguration configuration)
        {
            AddInfrastructureServices(services, configuration);
            AddUserDefineServices(services);
            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services ,IConfiguration configuration) 
        {
            services.AddDbContext<TraficViolationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            return services;
        }

        public static IServiceCollection AddUserDefineServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddSingleton<IOtpService, OtpService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProfileService, ProfileService>();
            return services;
        }
    }
}
