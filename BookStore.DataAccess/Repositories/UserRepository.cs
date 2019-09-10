using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        
        public UserRepository(TestAppContext dataBase) : base(dataBase)
        {
            
        }
        public string GetFirstName()
        {
            throw new NotImplementedException();
        }

        public string GetLastName()
        {
            throw new NotImplementedException();
        }

        public int GetPassword()
        {
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            throw new NotImplementedException();
        }

        public void SetFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public void SetLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(int password)
        {
            throw new NotImplementedException();
        }

        public void SetUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
