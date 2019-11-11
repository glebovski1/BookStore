using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic
{
    public static class MyIdentityDataInitializer
    {

        public static void SeedData(UserManager<User> userManager, RoleManager<Role> roleManager)
        {

        }

        public static async Task SeedUsers(UserManager<User> userManager)
        {
            User Admin = new User();
            Admin.UserName = "Admin";
            Admin.Email = "BookStoreGlebvoski@Gmail.com";
            string passwrod = "55555xxxxx";
        
            if (userManager.FindByNameAsync(Admin.UserName).Result == null)
            {
                IdentityResult identityResult = userManager.CreateAsync(Admin, passwrod).Result;
                
                if(identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(Admin, Enums.Roles.Admin.ToString());
                }
            }
        }

        public static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync(Enums.Roles.Admin.ToString()).Result)
            {
                Role role = new Role();
                role.Name = Enums.Roles.Admin.ToString();
                IdentityResult identityResult = await roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync(Enums.Roles.User.ToString()).Result)
            {
                Role role = new Role();
                role.Name = Enums.Roles.User.ToString();
                IdentityResult identityResult = await roleManager.CreateAsync(role);
            }
        }

    }
}
