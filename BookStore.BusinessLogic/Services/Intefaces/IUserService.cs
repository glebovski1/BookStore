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
       
        UserRepository UserRepository { get; set; }

        Task Registration(string userName, string firstName, string lastName, string emaill, string password);







    }
}
