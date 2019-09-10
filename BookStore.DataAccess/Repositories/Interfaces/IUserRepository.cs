using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {

     void SetFirstName(string firstName);

     void SetLastName(string lastName);

     void SetPassword(int password);

     void SetUserName(string userName);

     string GetFirstName();

     string GetLastName();

    int GetPassword();

    string GetUserName();
    }
}
