using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(TestAppContext dataBase) : base(dataBase)
        {

        }

        public async Task<Author> GetAuthorWithAuthorInRoles(int id)
        {
            return await _dbSet.Include(author => author.AuthorInBooks).FirstOrDefaultAsync(author => author.Id == id);
        }
    }
}
