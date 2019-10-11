using BookStore.BusinessLogic.Models;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Mappers
{
    public static class UserMapper
    {
        
        public static UserModel UserMappToModel(User userEntity)
        {
            UserModel userModel = new UserModel();
            userModel.FirstName = userEntity.FirstName;
            userModel.LastName = userEntity.LastName;
            userModel.Email = userEntity.Email;
            userModel.EmailConfirmed = userEntity.EmailConfirmed;
            userModel.UserName = userEntity.UserName;
            userModel.HashPassword = userEntity.PasswordHash;

            return userModel;
        }

        public static User UserMappToEntity(UserModel userModel)
        {
            User userEntiy = new User();
            userEntiy.Email = userModel.Email;
            userEntiy.EmailConfirmed = userModel.EmailConfirmed;
            userEntiy.FirstName = userModel.FirstName;
            userEntiy.LastName = userModel.LastName;
            userEntiy.Id = userModel.Id;
            userEntiy.IsRemoved = userModel.IsRemoved;
            userEntiy.UserName = userModel.UserName;

            return userEntiy;
        }

    }
}
