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
      
    }
}
