using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;

namespace TraficViolation.GB.Application.Abstractions.Token
{
    public interface ITokenServices
    {
        Task<string> CreateTokenAsync(AppUser appUser, UserManager<AppUser> userManager);

    }
}
