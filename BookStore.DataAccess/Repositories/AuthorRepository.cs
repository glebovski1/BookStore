using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(TestAppContext dataBase) : base(dataBase)
        {

        }

        public async Task<Author> FindByName(string name)
        {
            Author _author = await _dbSet.FirstOrDefaultAsync(author => author.Name == name);

            return _author;
        }
       
    }
}
