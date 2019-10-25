using BookStore.BusinessLogic.Models;
using BookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Intefaces
{
    public interface IPrintingEditionService
    {
        
        Task AddPrintingEdition(PrintingEditionModel printingEditionModel);

        Task<int> GetPeintingEditionIdByName(string name);

        Task DeletePrintingEditionById(int id);

        Task<PrintingEditionModel> GetPrintingEditionModel(int id);

        Task<List<PrintingEditionModel>> GetPrintingEditionModels(int page);

    }
}
