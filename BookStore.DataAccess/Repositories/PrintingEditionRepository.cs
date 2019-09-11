using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    class PrintingEditionRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {

        public PrintingEditionRepository(TestAppContext dataBase) : base(dataBase)
        {

        }
        public async Task<PrintingEdition> GetPrintingEditionWithAuthorInBooks(int id)
        {
            return await _dbSet.Include(printingEdition => printingEdition.AuthorInBooks).FirstOrDefaultAsync(printingEdition => printingEdition.Id == id);
        }
    }
}
