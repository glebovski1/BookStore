using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    class UserModel  : BaseModel
    {
        public UserModel()
        {

        }
        public UserModel(User userEnity) : base()
        {
            this.FirstName = userEnity.FirstName;
            this.LastName = userEnity.LastName;
            this.Email = userEnity.Email;
            this.EmailConfirmed = userEnity.EmailConfirmed;
            this.UserName = userEnity.UserName;
                        
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime CreationData { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public User MapToUserEntity()
        {
            User userEntiy = new User();
            userEntiy.CreationData = this.CreationData;
            userEntiy.Email = this.Email;
            userEntiy.EmailConfirmed = this.EmailConfirmed;
            userEntiy.FirstName = this.FirstName;
            userEntiy.LastName = this.LastName;
            userEntiy.Id = this.Id;
            userEntiy.IsRemoved = this.IsRemoved;
            userEntiy.UserName = this.UserName;

            return userEntiy;
        }
    }
}
