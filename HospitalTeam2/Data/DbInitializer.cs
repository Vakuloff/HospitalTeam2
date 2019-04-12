using HospitalTeam2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HospitalCMSContext context)
        {          
            context.Database.EnsureCreated();

            return;
        }

        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Staff" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }


            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com", FirstName = "Super", LastName = "Admin" };

                IdentityResult result = userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
}