using BookStore.DataAccess.Entities;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    interface IPrintingEditionRepository : IBaseRepository<PrintingEdition>
    {
        Task<PrintingEdition> GetPrintingEditionWithAuthorInBooks(int id);
    }
}
