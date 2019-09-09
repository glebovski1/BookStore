using BookStore.DataAccess.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class User : IdentityUser<int> 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
                
        public List<UserInRole> UserInRoles;

        public User()
        {
            UserInRoles = new List<UserInRole>();
        }

    }
}
