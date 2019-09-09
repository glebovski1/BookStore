using BookStore.DataAccess.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class UserInRole : BaseEntity
    {

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        
        public Role Role { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}
