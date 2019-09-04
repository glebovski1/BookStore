using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class UserInRole : BaseEntity
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }
    }
}
