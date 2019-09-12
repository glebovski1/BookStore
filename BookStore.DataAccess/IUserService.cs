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
        UserModel _UserModel { get; set; }
        UserRepository _UserRepository { get; set; }

        Task AddUser(string userName, string password);

        Task DeleteUser(int id);

        Task<int> FindUser(string userName);



    }
}
