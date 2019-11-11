using BookStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorInBooksRepository : IBaseRepository<AuthorInBook>
    {
        Task<Dictionary<int, List<AuthorInBook>>> GetByPrintingEditioIdList(List<int> autorInBooksIdList);
    }
}
