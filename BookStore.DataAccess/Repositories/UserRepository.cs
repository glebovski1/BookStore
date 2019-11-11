using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        

        public UserRepository(TestAppContext dataBase) : base(dataBase)
        {
            
        }
       
       

    }
}
