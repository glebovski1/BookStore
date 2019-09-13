using BookStore.BusinessLogic.Models;
using BookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Intefaces
{
    public interface IUserService
    {
        UserModel UserModel { get; set; }
        UserRepository UserRepository { get; set; }

        Task UserRegistration(string userName, string firstName, string lastName, string emaill, string password);







    }
}
