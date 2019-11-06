using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services;
using BookStore.BusinessLogic.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintingEditionController : ControllerBase
    {
        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        IPrintingEditionService _printingEditionService;

        [HttpPost("Post")]
        [Authorize(Roles = "Admin")]
        public async Task AddPrintingEdition([FromBody]PrintingEditionModel printingEditionModel)
        {
            await _printingEditionService.AddPrintingEdition(printingEditionModel);
        }

        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<PrintingEditionModel> GetPrintingEdition([FromBody]int id)
        {
            PrintingEditionModel response = await _printingEditionService.GetPrintingEditionModel(id);
            return response;
        }

        [HttpPost("GetAll")]
        [Authorize(Roles ="User, Admin")]
        public async Task<List<PrintingEditionModel>> GetAllPrintingEdition([FromBody]int page)
        {
            List<PrintingEditionModel> response = await _printingEditionService.GetPrintingEditionModels(page);
            return response;
        }

        [HttpPost("GetAllFiltred")]
        [Authorize(Roles="User, Admin")]
        public async Task<List<PrintingEditionModel>> GetAllPrintingFilterd([FromBody]FilterModel filterModel)
        {
            List<PrintingEditionModel> response = await _printingEditionService.GetPrintingEditionModelsFiltred(filterModel);
            return response;
        }
        [HttpPost("Delete")]
        [Authorize(Roles = "Admin")]

        public async Task Delete([FromBody]int id)
        {
            await _printingEditionService.DeletePrintingEditionById(id);
        }
    }
}