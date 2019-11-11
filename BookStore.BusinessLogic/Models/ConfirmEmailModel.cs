using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class ConfirmEmailModel
    {
        public UserModel UserModel { get; set; }
        public string ConfirmToken { get; set; }
    }
}
