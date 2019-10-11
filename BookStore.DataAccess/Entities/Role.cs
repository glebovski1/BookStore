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
        public DateTime DateTimeUtcNow { get; set; }
        public bool IsRemoved { get; set; }
        
        public Role()
        {
            DateTimeUtcNow = DateTime.UtcNow;
        }
    }
}
