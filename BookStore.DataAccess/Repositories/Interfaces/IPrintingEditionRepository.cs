using BookStore.DataAccess.Entities;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseRepository<Entities.PrintingEdition>
    {
        Task<int> GetPriceInCentes(int id);
    }
}
