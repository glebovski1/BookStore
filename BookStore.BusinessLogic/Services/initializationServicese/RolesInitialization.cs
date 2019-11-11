using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Entities;
using BookStore.BusinessLogic.Services.initializationServicese.Interfaces;

namespace BookStore.BusinessLogic.Services.initializationServicese
{
    public class RolesInitialization : IRolesInitialization
    {

        public RoleManager<Role> _roleManager;

        public RolesInitialization(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRoles()
        {
            bool isExite = await _roleManager.RoleExistsAsync(Enums.Roles.Admin.ToString());
            if (!isExite)
            {
                await _roleManager.CreateAsync(new Role {Name = Enums.Roles.Admin.ToString()});
            }
            isExite = await _roleManager.RoleExistsAsync(Enums.Roles.User.ToString());
            if (!isExite)
            {
                await _roleManager.CreateAsync(new Role {Name = Enums.Roles.User.ToString()});
            }
        }

    }
}
