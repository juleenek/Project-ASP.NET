using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using CentrumAdopcyjneZwierzat.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess
{
    public static class SeedData
    {
        public static void Seed(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
          
            if (userManager.FindByNameAsync("admin123").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin123",
                    Email = "admin123@admin.com",
                    FirstName = "admin",
                    LastName = "admin",
                    Phone = "111222333",
                    StreetAddress = "admin",
                    PostalCode = "11-222",
                    City = "admin"
                };
              
                var result = userManager.CreateAsync(user, "@dminPassword123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                var result = roleManager.CreateAsync(role).Result;

            }
        }
    }
}
