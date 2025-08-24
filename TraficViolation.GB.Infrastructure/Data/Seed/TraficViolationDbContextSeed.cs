using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Entities.Identity;

namespace TraficViolation.GB.Infrastructure.Data.Seed
{
    public static class TraficViolationDbContextSeed
    {
        public async static Task SeedAppUser(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    Email = "gamalwork81@gmail.com",
                    FullName = "Jamal Abdelsalam Mohamed",
                    UserName = "Jamal_11",
                    PhoneNumber = "123456789",
                };
                await _userManager.CreateAsync(user, "Jamal@123");
                await _userManager.AddToRoleAsync(user, "Admin");
            }


        }

        public async static Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Officer"))
                await roleManager.CreateAsync(new IdentityRole("Officer"));
            
            if (!await roleManager.RoleExistsAsync("VehicleOwner"))
                await roleManager.CreateAsync(new IdentityRole("VehicleOwner"));

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
        }
    }
}
