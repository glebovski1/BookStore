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
    public class PrintingEditionRepository : BaseRepository<Entities.PrintingEdition>, IPrintingEditionRepository
    {

        public PrintingEditionRepository(TestAppContext dataBase) : base(dataBase)
        {

        }
        public async Task<int> GetPriceInCentes(int id)
        {
            var printingEdition = await _dataBase.Set<PrintingEdition>().FindAsync(id);
            return Convert.ToInt32(printingEdition.Price * 100);
        }
      
    }
}
