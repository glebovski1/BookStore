using BookStore.DataAccess.Entities.BaseEntities;
using BookStore.DataAccess.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class Role : IdentityRole<int>, IBaseEntity
    {
      

      public List<UserInRole> UserInRoles;

      public Role()
      {
            UserInRoles = new List<UserInRole>();
      }

        public DateTime CreationData { get; set; }
        public bool IsRemoved { get; set; }
        int IBaseEntity.Id { get; set; }
    }
}
