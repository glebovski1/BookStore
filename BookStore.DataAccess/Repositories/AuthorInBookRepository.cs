using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class AuthorInBookRepository : BaseRepository<AuthorInBook>, IAuthorInBooksRepository
    {
        public AuthorInBookRepository(TestAppContext dataBase) : base(dataBase)
        {

        }

        public async Task<Dictionary<int, List<AuthorInBook>>> GetByPrintingEditioIdList(List<int> autorInBooksIdList)
        {
            Dictionary<int, List<AuthorInBook>> result = await _dbSet.Where(item => autorInBooksIdList.Contains(item.PrintingEditionId))
                                                       .Include(item => item.PrintingEdition)
                                                       .Include(item => item.Author)
                                                       .GroupBy(item => item.PrintingEditionId)
                                                       .ToDictionaryAsync(item => item.Key, value => value.ToList());

            return result;
        }
    }
}
