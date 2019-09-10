using BookStore.DataAccess.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class Role : IdentityRole
    {
      public string Name { get; set; }

      public List<UserInRole> UserInRoles;

      public Role()
      {
            UserInRoles = new List<UserInRole>();
      }


    }
}
