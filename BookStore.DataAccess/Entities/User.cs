using BookStore.DataAccess.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookStore.DataAccess.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime CreationData { get; set; }
        public bool IsRemoved { get; set; }

        public UserInRole UserInRole { get;set; }

       

    }
}
