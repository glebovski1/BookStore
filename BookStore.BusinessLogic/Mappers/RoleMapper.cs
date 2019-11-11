using BookStore.BusinessLogic.Models;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Mappers
{
   public static class RoleMapper
    {
        public static RoleModel RoleMappToModel(Role role)
        {
            RoleModel roleModel = new RoleModel();
            roleModel.Name = role.Name;
            return roleModel;

        }

        public static Role RoleMapToEntity(RoleModel roleModel)
        {
            Role roleEntity = new Role();
            roleEntity.Name = roleModel.Name;
            return roleEntity;
        }

    }
}
