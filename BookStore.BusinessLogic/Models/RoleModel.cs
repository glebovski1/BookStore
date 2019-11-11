using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class RoleModel : BaseModel
    {
        public RoleModel()
        {
        }

        public RoleModel(Role roleEntity)
        {
            this.Name = roleEntity.Name;

        }
        public string Name { get; set; }

        public Role MapToRoleEntity()
        {
            Role role = new Role();
            role.Name = this.Name;
            return role;
        }
    }
}
