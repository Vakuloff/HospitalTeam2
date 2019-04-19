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

        public static async Task CreateRoles(HospitalCMSContext context, IServiceProvider serviceProvider)
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

            string[] menuNames =
                {
                    "Patients/Visitors",
                    "About Us",
                    "Volunteers",
                    "Contact",
                    "Blog",
                    "Donation",
                    "Staff Schedule",
                    "Find a Doctor",
                    "Book Appointment",
                    "parking",
                    "Careers",
                    "Emergency Alert",
                    "Event Calender"
                };

            foreach (var menu in menuNames)
            {               
                if (!context.NavMenus.ToList().Exists(nav => nav.Title == menu))
                {
                    if(menu== "Patients/Visitors")
                    {
                        context.Add(new NavMenu() { Title=menu,IsShown=true,Url= "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "About Us")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "Volunteers")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "Contact")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "Blog")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "Donation")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "Staff Schedule")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Menus" });
                        context.SaveChanges();
                    }
                    else if (menu == "Find a Doctor")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "/Staff/find" });
                        context.SaveChanges();
                    }
                    else if (menu == "Book Appointment")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "#" });
                        context.SaveChanges();
                    }
                    else if (menu == "parking")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "#" });
                        context.SaveChanges();
                    }
                    else if (menu == "Careers")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "#" });
                        context.SaveChanges();
                    }
                    else if (menu == "Emergency Alert")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "#" });
                        context.SaveChanges();
                    }
                    else if (menu == "Event Calender")
                    {
                        context.Add(new NavMenu() { Title = menu, IsShown = true, Url = "#" });
                        context.SaveChanges();
                    }


                }
            }

        }
    }
}